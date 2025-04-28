using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensibility;
using RabbitMQ.Client;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;
using System.Runtime.CompilerServices;
using System.Text;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class RaporController : Controller
    {
        private readonly IRaporBs _raporBs;
        ISessionManager _session;
        public RaporController(IRaporBs raporBs, ISessionManager session)
        {
            _raporBs = raporBs;
            _session = session;

        }
        public IActionResult Index()
        {


            RaporIndexViewModel model = new RaporIndexViewModel();
            model.RaporListesi = _raporBs.GetAll();

            // Buradan id RAbbitMQ ya gönderildi. Yani burası publish etti
            // Worker Servis Rabbbit daki id yi alıp işleyecek. Yani consume edecek

            return View(model);
        }
        public IActionResult CreateRapor()
        {

            Rapor rap = new Rapor();

            rap.Aktif = true;
            rap.Durum = 0;// hazırlanıyor
            rap.TalepTarih = DateTime.Now;
            rap.RaporTipId = 1;

            rap.OlusturanId = _session.AktifYonetici.Id;


            rap = _raporBs.Insert(rap);
            // Raporu insert Et. Aynı zamanda listenin son halini dön
            // RabbitMQ ya Id sini gönder.

            // RABBITMQ İŞLEMLERİ

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";


            // Connection Oluşturuldu
            IConnection con = factory.CreateConnectionAsync().Result;


            // Kanal Oluşturuldu
            IChannel channel = con.CreateChannelAsync().Result;




            //-----------------------------------------------------
            channel.ExchangeDeclareAsync("raporexchange", ExchangeType.Direct, true, false, null);

            string queuename = "raporqueue";
            string routekey = "route";
            channel.QueueDeclareAsync(queuename, true, false, false, null);

            channel.QueueBindAsync(queuename, "raporexchange", routekey, null);

            byte[] mesajbody = Encoding.UTF8.GetBytes(rap.Id.ToString());


            channel.BasicPublishAsync("raporexchange", routekey, mesajbody);
            // RABBITMQ YA Id Gönderildi.

            RaporIndexViewModel model = new RaporIndexViewModel();
            model.RaporListesi = _raporBs.GetAll();


            // Buradan id RAbbitMQ ya gönderildi. Yani burası publish etti
            // Worker Servis Rabbbit daki id yi alıp işleyecek. Yani consume edecek

            return RedirectToAction("Index");
        }
    }
}
