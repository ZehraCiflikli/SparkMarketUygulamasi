using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{


    [Area("AdminPanel")]
    public class KdvController : Controller
    {


        private readonly IKdvBS _kdvBS;
        public KdvController(IKdvBS kdvBS)
        {
            _kdvBS = kdvBS;
        }




        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult List()
        {
            List<Kdv> kdv = _kdvBS.GetAll();

            return Json(new { data = kdv });
        }


        public IActionResult AktifPasif(int id, bool aktif)
        {
            Kdv kdv = _kdvBS.Get(x => x.Id == id);
            kdv.Aktif = aktif;
            _kdvBS.Update(kdv);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }

        [HttpPost]
        public IActionResult Add(KdvIndexViewModel k)
        {
            Kdv kdv = new Kdv();
            kdv.KdvAdi = k.KdvAdi;
            kdv.KdvOrani = k.KdvOrani;

            _kdvBS.Insert(kdv);

            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult GetKdv(int id)
        {


            Kdv kdv = _kdvBS.Get(x => x.Id == id);

            return Json(new { result = true, model = kdv });

        }



        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Kdv kdv = _kdvBS.Get(x => x.Id == Id);

            double oran = 0; // Varsayılan değer

            if (!double.TryParse(data["KdvOrani"], out oran))
            {
                return BadRequest("Geçersiz KDV oranı.");
            }



            kdv.KdvAdi = data["KdvAdi"];
            kdv.KdvOrani = oran;




            _kdvBS.Update(kdv);



            return Json(new { result = true, mesaj = "Kdv Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Kdv kdv = _kdvBS.Get(x => x.Id == id);

            _kdvBS.Delete(kdv);

            return Json(new { result = true });


        }



    }
}
