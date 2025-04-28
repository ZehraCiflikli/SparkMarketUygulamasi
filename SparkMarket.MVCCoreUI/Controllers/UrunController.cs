using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.MVCCoreUI.Filters;
using SparkMarket.MVCCoreUI.Models;
using static iTextSharp.text.pdf.AcroFields;

namespace SparkMarket.MVCCoreUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        IUrunBS _urunBS;
        IKategoriBS _kategoriBS;
        IRaporBs _raporBs;
        IHubContext<RaporHub> _hubContext;
        IUserConnectionManager _connectionManager;
        public UrunController(IUrunBS urunBS, IKategoriBS kategoriBS, IRaporBs raporBs, IHubContext<RaporHub> hubContext, IUserConnectionManager connectionManager)
        {
            _urunBS = urunBS;
            _kategoriBS = kategoriBS;
            _raporBs = raporBs;
            _hubContext = hubContext;
            _connectionManager = connectionManager;


        }

        [HttpGet]
        public List<Urun> UrunListesi()
        {

            List<Urun> urunler = _urunBS.GetAll();
            return urunler;

        }

        [HttpPost]
        public IActionResult Post([FromQuery] int id)
        {

            using (var ms = new MemoryStream())
            {
                HttpContext.Request.Body.CopyToAsync(ms);
                var bytes = ms.ToArray();
                Rapor r = _raporBs.GetById(id);
                if (r != null)
                {
                    string raporname = Guid.NewGuid().ToString().Replace("-", "");
                    System.IO.File.WriteAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/raporlar/" + raporname + ".pdf"), bytes);

                    r.RaporUrl = "/raporlar/" + raporname + ".pdf";
                    r.RaporTarih = DateTime.Now;
                    r.Durum = 1;
                    _raporBs.Update(r);

                    Thread.Sleep(4000);



                    var connectionIds = _connectionManager.GetConnectionId(r.OlusturanId.Value.ToString());

                    if (connectionIds.Any())
                    {
                        foreach (var connectionId in connectionIds)
                        {
                             _hubContext.Clients.Client(connectionId).SendAsync("CompletedFile");
                        }
                    }

                }

            }




            return Ok();

        }
    }
}
