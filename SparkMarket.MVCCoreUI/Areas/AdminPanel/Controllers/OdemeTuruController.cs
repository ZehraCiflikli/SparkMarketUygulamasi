using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class OdemeTuruController : Controller
    {
      private readonly  IOdemeTuruBS _odemeTuruBS;
        public OdemeTuruController(IOdemeTuruBS odemeTuruBS)
        {
            _odemeTuruBS = odemeTuruBS;
        }
        public IActionResult Index()
        {
            OdemeTuruIndexViewModel model = new OdemeTuruIndexViewModel();
            model.OdemeTuruListe = _odemeTuruBS.GetAll();

            return View(model);
        }
        [HttpPost]
        public IActionResult List()
        {
            List<OdemeTuru> odemeTuru = _odemeTuruBS.GetAll().ToList();
            return Json(new { data = odemeTuru });
        }
        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            OdemeTuru odemeTuru = new OdemeTuru();
            odemeTuru.OdemeTuruAdi = data["OdemeTuruAdi"];
            _odemeTuruBS.Insert(odemeTuru);

            List<OdemeTuru> model = _odemeTuruBS.GetAll();
            OdemeTuruIndexViewModel odemeTuruIndex = new OdemeTuruIndexViewModel();
            return Json(new { result = true, mesaj = "Ödeme Türü Başarıyla Eklendi" , model = model });
        }
        [HttpPost]
        public IActionResult Update(IFormCollection data) 
        {
            int Id = Convert.ToInt32(data["Id"]);
            OdemeTuru ot = _odemeTuruBS.Get(x => x.Id == Id);
            ot.OdemeTuruAdi = data["OdemeTuruAdi"];
            _odemeTuruBS.Update(ot);

            List<OdemeTuru> odemeTuru = _odemeTuruBS.GetAll();
            OdemeTuruIndexViewModel model = new OdemeTuruIndexViewModel();
            return Json(new { result = true, mesaj = "Ödeme Türü Başarıyla Güncellendi" });

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            OdemeTuru ot = _odemeTuruBS.Get(x => x.Id == id);
            _odemeTuruBS.Delete(ot);

            return Json(new { result=true, mesaj="Ödeme Türü Başarıyla Silindi!" });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            OdemeTuru ot = _odemeTuruBS.Get(x => x.Id == id);
            ot.Aktif = aktif;
            _odemeTuruBS.Update(ot);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });
        }
        public IActionResult GetOdemeTuru(int id)
        {
            OdemeTuru ot = _odemeTuruBS.Get(x => x.Id == id);
            return Json(new { result = true, model = ot });
        }
           
    }
}
