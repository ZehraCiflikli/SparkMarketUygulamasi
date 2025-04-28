using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;

namespace SparkMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        IUrunBS _urunBS;
        IKategoriBS _kategoriBS;
        IRaporBs _raporBs;
        public UrunController(IUrunBS urunBS, IKategoriBS kategoriBS, IRaporBs raporBs)
        {
            _urunBS = urunBS;
            _kategoriBS = kategoriBS;
            _raporBs= raporBs;  
        }

        [HttpGet]
        public List<Urun> UrunListesi()
        {

            List<Urun> urunler = _urunBS.GetAll();
            return urunler;

        }
        //[HttpPost]
        //public List<Urun> Upload(IFormFile file, int id)
        //{
        //   Rapor r =   _raporBs.GetById(id);
        //    if (r!=null)
        //    {

        //        var filepath = file.FileName + Path.GetExtension(file.FileName);
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/raporlar", filepath);




        //    }





        //}
        // ENDPOINT dışarıya açık olan adresler benim endpoint lerimdir.
        // 


        // HTTPGET
        //--------------------------------------------
        // /api/Urun      Tüm Ürünleri Getir 
        // /api/Urun/5    5 idli ürünü getirsin
        // api/Urun/kategori/4  4 idli kategorideki ürünlerimi getir.

        // api/kategori   Kategori listesi getirsin


        // HTTPPOST INSERT

        // HTTPPUT UPDATE

        // HTTPDELETE DİL




    }
}
