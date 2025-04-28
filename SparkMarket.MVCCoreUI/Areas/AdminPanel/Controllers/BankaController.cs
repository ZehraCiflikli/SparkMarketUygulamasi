using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Data.Concrete.EntityFramework.repository;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    
    public class BankaController : Controller
    {

        private readonly IBankaBS _bankaBs;
       
        public BankaController(IBankaBS bankaBs)
        {
            _bankaBs=bankaBs;
           
        }


        public IActionResult Index()
        {
                 

            return View();
        }


        [HttpPost]
        public IActionResult List()
        {
            List<Banka> bankalar = _bankaBs.GetAll();

            return Json(new { data = bankalar });
        }


        [HttpPost]
        public IActionResult Add(BankaIndexViewModel b)
        {
            Banka bk = new Banka();
            bk.BankaAdi = b.BankaAdi;

            _bankaBs.Insert(bk);

            return Json(new { result = true, mesaj = "Banka Başasıyla Eklendi" });

        }





        public IActionResult AktifPasif(int id, bool aktif)
        {
            Banka bk = _bankaBs.Get(x => x.Id == id);
            bk.Aktif = aktif;
            _bankaBs.Update(bk);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }



        [HttpPost]
        public IActionResult GetBanka(int id)
        {


            Banka bk = _bankaBs.Get(x => x.Id == id);

            return Json(new { result = true, model = bk });

        }


        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Banka bk = _bankaBs.Get(x => x.Id == Id);


            bk.BankaAdi = data["BankaAdi"];

            _bankaBs.Update(bk);



            return Json(new { result = true, mesaj = "Banka Başasıyla Güncellendi" });
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            Banka bk = _bankaBs.Get(x => x.Id == id);

            _bankaBs.Delete(bk);

            return Json(new { result = true });


        }

    }
}
