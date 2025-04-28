using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MarkaController : Controller
    {
        private readonly IMarkaBS _markaBS;
        public MarkaController(IMarkaBS markaBS)
        {
            _markaBS = markaBS;
        }
        public IActionResult Index()
        {
            MarkaIndexViewModel model = new MarkaIndexViewModel();
            List<Marka> markalar = _markaBS.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            List<Marka> markalar = _markaBS.GetAll();
            return Json(new { data = markalar });
        }

        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            Marka m = new Marka();
            m.MarkaAdi = data["MarkaAdi"];
            _markaBS.Insert(m);
            List<Marka> markalar = _markaBS.GetAll();
            MarkaIndexViewModel model = new MarkaIndexViewModel();
            return Json(new { result = true, mesaj = "Marka Başarıyla Eklendi", model = model });
        }
        [HttpPost]

        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Marka m = _markaBS.Get(x => x.Id == Id);
            m.MarkaAdi = data["MarkaAdi"];
            _markaBS.Update(m);
            List<Marka> markalar = _markaBS.GetAll();
            MarkaIndexViewModel model = new MarkaIndexViewModel();
            return Json(new { result = true, mesaj = "Marka Başarıyla Güncellendi", model = model });
        }
        [HttpPost]

        public IActionResult Delete(int id)
        {
            Marka m = _markaBS.Get(x => x.Id == id);
            _markaBS.Delete(m);
            List<Marka> markalar = _markaBS.GetAll();
            MarkaIndexViewModel model = new MarkaIndexViewModel();
            return Json(new { result = true, mesaj = "Marka Başarıyla Silindi", model = model });

        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Marka m = _markaBS.Get(x => x.Id == id);
            m.Aktif = aktif;
            _markaBS.Update(m);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });
        }

        public IActionResult GetMarka(int id)
        {
            Marka m = _markaBS.Get(x => x.Id == id);
            return Json(new { result = true, model = m });
        }
    }
}
