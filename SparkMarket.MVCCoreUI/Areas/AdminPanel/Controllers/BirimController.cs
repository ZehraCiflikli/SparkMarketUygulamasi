using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BirimController : Controller
    {
        private readonly IBirimBs _birimBS;

        public BirimController(IBirimBs birimBS)
        {
            _birimBS = birimBS;
        }


       
        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public IActionResult List()
        {
            List<Birim> birimler = _birimBS.GetAll();

            return Json(new { data = birimler });
        }


        [HttpPost]
        public IActionResult Add(BirimIndexViewModel b)
        {
            Birim bm = new Birim();
            bm.BirimAdi = b.BirimAdi;

            _birimBS.Insert(bm);

            return Json(new { result = true, mesaj = "Birim Başasıyla Eklendi" });

        }





        public IActionResult AktifPasif(int id, bool aktif)
        {
            Birim br = _birimBS.Get(x => x.Id == id);
            br.Aktif = aktif;
            _birimBS.Update(br);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }



        [HttpPost]
        public IActionResult GetBirim(int id)
        {

          
            Birim br = _birimBS.Get(x => x.Id == id);

            return Json(new { result = true, model = br });

        }


        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Birim br = _birimBS.Get(x => x.Id == Id);


            br.BirimAdi = data["BirimAdi"];
          
            _birimBS.Update(br);



            return Json(new { result = true, mesaj = "Birim Başasıyla Güncellendi" });
        }




        [HttpPost]
        public IActionResult Delete(int id) 
        { 
            Birim br =_birimBS.Get(x=>x.Id== id);

            _birimBS.Delete(br);

            return Json(new { result = true });


        }




    }
}
