using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Common;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class KategoriController : Controller
    {
        private readonly IKategoriBS _kategoriBS;
        private readonly ISessionManager _sesion;
        public KategoriController(IKategoriBS kategoriBS, ISessionManager sesion)
        {
            _kategoriBS = kategoriBS;
            _sesion = sesion;
        }
        public IActionResult Index()
        {


            KategoriIndexViewModel model = new KategoriIndexViewModel();


            List<Kategori> kategoriler = _kategoriBS.GetAll();

            model.UstKategoriListe = kategoriler.Select(x => new SelectListItem() { Text = x.UstKategoriGorunum, Value = x.Id.ToString() }).ToList();

            model.UstKategoriListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Kategori Seçiniz", Value = "0", Selected=true });




            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {

            List<Kategori> kategoriler = _kategoriBS.GetAll();

            return Json(new { data = kategoriler });
        }

        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {

            // Kategori Görünüm

            // Bilgisayar                Bilgisayar
            // İşlemci                   Bilgisayar >> İşlemci
            // i7                      Bilgisayar >> İşlemci >> i7
            // Giyim                Giyim

            Kategori k = new Kategori();
            k.KategoriAdi = data["KategoriAdi"];
            k.Aciklama = data["Aciklama"]; // İçinde html kodları var
            k.UstKategoriId = Convert.ToInt32(data["UstKategoriId"]);
            k.OlusturanId = _sesion.AktifYonetici.Id;
            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/kategori/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        k.Resim = "/images/kategori/" + newFileName;
                    }
                }

            }


            if (k.UstKategoriId == 0)
            {
                //k.UstKategoriId = -1;
                k.UstKategoriGorunum = k.KategoriAdi;
                k.UstKategoriId = null;

            }
            else
            {
                // k.UstKategoriId = model.UstKategoriId;
                Kategori ustKategori = _kategoriBS.Get(x => x.Id == k.UstKategoriId);

                k.UstKategoriGorunum = ustKategori.UstKategoriGorunum + " >> " + k.KategoriAdi;

            }

            _kategoriBS.Insert(k);

            //RedisOpearations.SetObject<Kategori>("Kat", k, 0);


            //--------------MODAL İÇİN-----------------------
            List<Kategori> kategoriler = _kategoriBS.GetAll();

            KategoriIndexViewModel model = new KategoriIndexViewModel();


            model.UstKategoriListe = kategoriler.Select(x => new SelectListItem() { Text = x.UstKategoriGorunum, Value = x.Id.ToString() }).ToList();

            model.UstKategoriListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Kategori Seçiniz", Value = "0", Selected = true });


            return Json(new { result = true, mesaj = "Kategori Başasıyla Eklendi", model = model });
        }

        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);

            Kategori k = _kategoriBS.Get(x => x.Id == Id);

            k.KategoriAdi = data["KategoriAdi"];
            k.Aciklama = data["Aciklama"]; // İçinde html kodları var
            k.DegistirenId = _sesion.AktifYonetici.Id;
            if (!string.IsNullOrEmpty(data["UstKategoriId"].ToString()))
            {
                k.UstKategoriId = Convert.ToInt32(data["UstKategoriId"]);
            }
            else
            {
                k.UstKategoriId = 0;
            }


            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/kategori/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        k.Resim = "/images/kategori/" + newFileName;
                    }
                }

            }

            if (k.UstKategoriId == 0)
            {
                //k.UstKategoriId = -1;
                k.UstKategoriGorunum = k.KategoriAdi;
                k.UstKategoriId = null;
            }
            else
            {
                // k.UstKategoriId = model.UstKategoriId;
                Kategori ustKategori = _kategoriBS.Get(x => x.Id == k.UstKategoriId);

                k.UstKategoriGorunum = ustKategori.UstKategoriGorunum + " >> " + k.KategoriAdi;
            }

            _kategoriBS.Update(k);




            List<Kategori> kategoriler = _kategoriBS.GetAll();

            KategoriIndexViewModel model = new KategoriIndexViewModel();


            model.UstKategoriListe = kategoriler.Select(x => new SelectListItem() { Text = x.UstKategoriGorunum, Value = x.Id.ToString() }).ToList();

            if (k.UstKategoriId == 0)
            {
                model.UstKategoriListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Kategori Seçiniz", Value = "0", Selected = true });
            }
            else
            {
                model.UstKategoriListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Kategori Seçiniz", Value = "0" });
            }
            //model.Resim = k.Resim;
            model.kategori = k;



            return Json(new { result = true, mesaj = "Kategori Başasıyla Güncellendi", model = model });
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Kategori k = _kategoriBS.Get(x => x.Id == id);
            k.Aktif = aktif;
            _kategoriBS.Update(k);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }


        public IActionResult GetKategori(int id)
        {

            Kategori k = _kategoriBS.Get(x => x.Id == id);


            return Json(new { result = true, model = k });

        }

    }
}

// Birim Listele, Ekle,Sil,Güncelle
// Kargo Listele, Ekle,Sil,Güncelle
// Kdv Listele, Ekle,Sil,Güncelle
// Marka Listele, Ekle,Sil,Güncelle
// Menu Listele, Ekle,Sil,Güncelle
// Rol Listele, Ekle,Sil,Güncelle