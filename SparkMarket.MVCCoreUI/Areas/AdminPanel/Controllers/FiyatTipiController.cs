using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FiyatTipiController : Controller
    {
        private readonly IFiyatTipiBS _fiyatTipiBS;
        public FiyatTipiController(IFiyatTipiBS fiyatTipiBS)
        {
            _fiyatTipiBS = fiyatTipiBS;
        }

        public IActionResult Index()
        {
            FiyatTipiIndexViewModel model = new FiyatTipiIndexViewModel();
            model.FiyatTipiListe = _fiyatTipiBS.GetAll();
            return View(model);
            
        }
        [HttpPost]
        public IActionResult List()
        {
          List<FiyatTipi> ft= _fiyatTipiBS.GetAll().ToList();
            return Json(new {data=ft});

        }

        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            FiyatTipi fiyatTipi = new FiyatTipi();
            fiyatTipi.FiyatTipiAdi = data["FiyatTipiAdi"];

            _fiyatTipiBS.Insert(fiyatTipi);

            List<FiyatTipi> model = _fiyatTipiBS.GetAll();
            FiyatTipiIndexViewModel fiyatTipiIndex = new FiyatTipiIndexViewModel();

            return Json(new { result = true, mesaj = "Fiyat Tipi Başarıyla Eklendi", model = model });


        }
        [HttpPost]
        public IActionResult Update(IFormCollection data)
        { 
            int Id=Convert.ToInt32(data["Id"]);
            FiyatTipi ft= _fiyatTipiBS.Get(x=>x.Id==Id);
            ft.FiyatTipiAdi = data["FiyatTipiAdi"];
            _fiyatTipiBS.Update(ft);

            List<FiyatTipi> fiyattipi= _fiyatTipiBS.GetAll();
            FiyatTipiIndexViewModel model= new FiyatTipiIndexViewModel();

            return Json(new { result = true, mesaj="Fiyat Tipi Başarıyla Güncellendi"});

        
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
           FiyatTipi ft= _fiyatTipiBS.Get(x=>x.Id == id);
            _fiyatTipiBS.Delete(ft);
            return Json(new { result = true, mesaj = "Fiyat Tipi Başarıyla Silindi" });

        }
        
        public IActionResult AktifPasif(int id,bool aktif)
        {

           FiyatTipi ft=_fiyatTipiBS.Get(x=>x.Id == id);
            ft.Aktif= aktif;
            _fiyatTipiBS.Update(ft);

            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });
           
        }

        public IActionResult GetFiyatTipi(int id)
        {
            FiyatTipi fiyattipi = _fiyatTipiBS.Get(x => x.Id == id);

            return Json(new {result=true,model=fiyattipi});
        }
    }
}
