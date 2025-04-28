using AutoMapper;
using Infrastructure.CrossCuttingConcern.Converters;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{


    public class Fiyatlar
    {
        public int fiyatTipi { get; set; }
        public decimal fiyat { get; set; }

    }
 



    [Area("AdminPanel")]
    [YoneticiFilter]
    public class UrunController : Controller
    {

        IUrunBS _urunBS;
        IKategoriBS _kategoriBS;
        IBirimBs _birimBs;
        IMarkaBS _markaBS;
        IKdvBS _kdvBS;
        IUrunFiyatBS _urunFiyatBS;
        IUrunIndirimBS _urunIndirimBS;
        IUrunOzellikDegerBS _urunOzellikDegerBS;
        IFiyatTipiBS _fiyatTipiBS;
        IMapper _mapper;
        ISessionManager _session;
        IUrunResimBS _urunResimBS;
        public UrunController(IUrunBS urunBS,
        IKategoriBS kategoriBS,
        IBirimBs birimBs,
        IMarkaBS markaBS,
        IKdvBS kdvBS,
        IUrunFiyatBS urunFiyatBS,
        IUrunIndirimBS urunIndirimBS,
        IFiyatTipiBS fiyatTipiBS,
        IUrunOzellikDegerBS urunOzellikDegerBS,
        IMapper mapper,
        ISessionManager session,
        IUrunResimBS urunResimBS)
        {

            _urunBS = urunBS;
            _kategoriBS = kategoriBS;
            _markaBS = markaBS;
            _kdvBS = kdvBS;
            _birimBs = birimBs;
            _urunIndirimBS = urunIndirimBS;
            _urunOzellikDegerBS = urunOzellikDegerBS;
            _urunFiyatBS = urunFiyatBS;
            _fiyatTipiBS = fiyatTipiBS;
            _mapper = mapper;
            _session = session;
            _urunResimBS = urunResimBS;
        }
        public IActionResult Index()
        {



            return View();
        }

        public IActionResult List()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);
            int start = Convert.ToInt32(Request.Form["start"]);
            int length = Convert.ToInt32(Request.Form["length"]);
            int sortColumnIdx = Convert.ToInt32(Request.Form["order[0][column]"]);
            string searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            string sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault(); // asc desc


            Expression<Func<Urun, bool>> filter = null;
            if (!string.IsNullOrEmpty(searchValue))
            {
                filter = x => x.UrunAdi.Contains(searchValue) || x.Kategori.KategoriAdi.Contains(searchValue);
            }

            // İki tane expression yani filter nasıl birleştirilir, combine edilir.

            PagingResult<Urun> urun = _urunBS.GetAllPaging(start, length, filter, orderby: null, Sorted.ASC, "Kategori", "Marka", "Kdv", "Birim", "UrunResims");



            return Json(new
            {
                data = urun.Data,
                draw = Request.Form["draw"],
                recordsFiltered = urun.TotalCount,
                recordsTotal = urun.TotalItemCount
            });
        }


        public IActionResult Add()
        {



            UrunAddViewModel model = new UrunAddViewModel();

            model.KategoriListe = _kategoriBS.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.UstKategoriGorunum, Value = x.Id.ToString() }).ToList();
            model.KategoriListe.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen Kategori Seçiniz...", Value = "0", Selected = true });



            model.MarkaListe = _markaBS.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.MarkaAdi, Value = x.Id.ToString() }).ToList();
            model.MarkaListe.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen Marka Seçiniz...", Value = "0", Selected = true });


            model.KdvListe = _kdvBS.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.KdvAdi, Value = x.Id.ToString() }).ToList();
            model.KdvListe.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen KDV Oranı Seçiniz...", Value = "0", Selected = true });

            model.BirimListe = _birimBs.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.BirimAdi, Value = x.Id.ToString() }).ToList();
            model.BirimListe.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen Birim Seçiniz...", Value = "0", Selected = true });


            model.FiyatTipleri = _fiyatTipiBS.GetAll(x => x.Aktif == true);


            return View(model);

        }
        [HttpPost]
        public IActionResult Add(UrunAddViewModel model)
        {

            Urun urun = _mapper.Map<Urun>(model);
            urun.BirimId = urun.BirimId == 0 ? null : urun.BirimId;
            urun.MarkaId = urun.MarkaId == 0 ? null : urun.MarkaId;
            urun.KategoriId = urun.KategoriId == 0 ? null : urun.KategoriId;
            urun.KdvId = urun.KdvId == 0 ? null : urun.KdvId;
            urun = _urunBS.Insert(urun);

            if (_session.Dosyalar != null)
            {
                foreach (Dosya item in _session.Dosyalar)
                {
                    UrunResim resim = new UrunResim();
                    resim.UrunId = urun.Id;
                    resim.ResimUrl = item.Url;

                    _urunResimBS.Insert(resim);
                }
            }
            _session.Dosyalar = null;

            return Json(new { result = true, id = urun.Id });
        }





        // TEMA DAKİ DROPZON İÇİN 
        public IActionResult AddFile(IFormFile file)
        {
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

                string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/urun/" + newFileName;
                using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                return Json(new { status = true, fileName = newFileName });
            }
            else
            {
                return NotFound();
            }



        }


        public IActionResult AddFile2(IFormFile file)
        {

            //ConnectionFactory factory = new ConnectionFactory();
            //factory.HostName = "localhost";
            //factory.Port = 5672;
            //factory.UserName = "guest";
            //factory.Password = "guest";


            //IConnection con = factory.CreateConnectionAsync().Result;
            //IChannel channel = con.CreateChannelAsync().Result;





            return Json(new { });
        }


        [HttpPost]
        public IActionResult FileUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { success = false, message = "Dosya yüklenemedi!" });
            }

            string fileName = $"{Path.GetFileName(file.FileName)}";  // Sipariş no ile dosya adını eşle
            string filePath = Path.Combine("/wwwroot/images/urun/", fileName);

            // SESSION İÇERİSİNDE bir kolleksiyon varsa, bu kolleksiyonu doğrudan kullanarak session üzerinden kolleksiyona eleman ekleme YAPAMIYORUZ: Önce sessindeki listeyi rame çekip ram de doldurup veya değiştitip sonra session a tekrar atmamız gerekiyor.



            List<Dosya> dosyalar;
            if (_session.Dosyalar == null)
            {
                dosyalar= new List<Dosya>();
            }
            else
            {
                dosyalar = _session.Dosyalar;
            }



            Dosya d = new Dosya();
            d.FileName = fileName;
            d.Size = file.Length;
            d.Url = "/images/urun/" + fileName;

            dosyalar.Add(d);

            _session.Dosyalar = dosyalar;


           

            string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/urun/" + fileName;



            using (var stream = new FileStream(uploadpath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            return Ok(new { success = true, fileName = fileName });
        }

        [HttpDelete]
        public IActionResult DeleteFile(string fileName)
        {

            string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/urun/" + fileName;



            string filePath = Path.Combine("/wwwroot/images/urun/", fileName);
            //string fileName = $"{Path.GetFileName(file.FileName)}";

            if (_session.Dosyalar != null)
            {
                Dosya d = _session.Dosyalar.SingleOrDefault(x => x.FileName == fileName);
                _session.Dosyalar.Remove(d);

            }


            if (System.IO.File.Exists(uploadpath))
            {
                System.IO.File.Delete(uploadpath);

                return Ok(new { success = true });

            }

            return NotFound(new { success = false, message = "Dosya bulunamadı!" });
        }



        public IActionResult AddFiyat(List<Fiyatlar> fiyatlar, int id)
        {

            foreach (Fiyatlar item in fiyatlar)
            {
                _urunFiyatBS.Insert(new UrunFiyat() { FiyatTipiId = item.fiyatTipi, UrunFiyati = item.fiyat, UrunId = id });
            }

            return Json(new { result = true });
        }
        [HttpPost]
        public IActionResult KdvList()
        {

            List<Kdv> kdvler = _kdvBS.GetAll(x => x.Aktif == true);

            return Json(new { result = true, data = kdvler });
        }
    }

}

