using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Serilog;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.DTO;
using SparkMarket.Model.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SparkMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        // api/kategori

        IUrunBS _urunBS;
        IKategoriBS _kategoriBS;
        IMapper _mapper;
        public KategoriController(IUrunBS urunBS, IKategoriBS kategoriBS, IMapper mapper)
        {
            _urunBS = urunBS;
            _kategoriBS = kategoriBS;
            _mapper = mapper;
        }

        [HttpGet]
        // Controller üzerinde yazılı olan route yapısına action metot a verdiğim route yapısı
        public ApiResponse<List<KategoriDTO>> Get()
        {
            // api/kategori

            // Api Authentication ları için daha çok request in headersı üzerinden gerçekleştrimesine rağmen günümüzde jwt json web token kullanılmaya başlanmıştır.
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            if (username == "admin" && password == "12345")
            {
                Log.Information("Bu bir bilgi logudur");
                Log.Warning("Bu bir uyarı logudur");
                Log.Error("Bu bir hata logudur");

                List<Kategori> kategoriler = _kategoriBS.GetAll();

                List<KategoriDTO> data = _mapper.Map<List<KategoriDTO>>(kategoriler);


                // WSDL Adresi
                // Servisin Adresi

                return new ApiResponse<List<KategoriDTO>>(true, "", data);
            }
            else
            {
                return new ApiResponse<List<KategoriDTO>>(false, "Authentication Başarısız", null);
            }

        }


        [HttpGet]
        // Controller üzerinde yazılı olan route yapısına action metot a verdiğim route yapısı
        [Route("{id}")]
        public KategoriDTO TumunuGetir(int id)
        {
            // api/kategori/id httpget
            Kategori kategori = _kategoriBS.GetById(id);
            return _mapper.Map<KategoriDTO>(kategori);
        }


        [HttpPost]
        // Controller üzerinde yazılı olan route yapısına action metot a verdiğim route yapısı

        public IActionResult Ekle(KategoriDTO dto)
        {
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            if (username == "admin" && password == "12345")
            {
                if (ModelState.IsValid)
                {
                    Kategori kat = _mapper.Map<Kategori>(dto);
                    Kategori kategori = _kategoriBS.Insert(kat);

                    KategoriDTO result = _mapper.Map<KategoriDTO>(kategori);

                    return Ok("Kategori Oluşturuldu");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("Kullanıcı Adı Şifre hatalı");
            }

        }

        // Web Api
        // Automapper
        // FluentValidation


        // Güncelleme için kullanılır. Ancak nesnenin tüm değerleri güncellencek olarak değerlendirilir.
        // 
        [HttpPut]
        public IActionResult Put([FromBody] KategoriDTO dto)
        {
            Kategori kat = _mapper.Map<Kategori>(dto);

            Kategori dbkat = _kategoriBS.Get(x => x.Id == kat.Id);

            if (dbkat != null)
            {
                Kategori kategori = _kategoriBS.Update(kat);

                KategoriDTO result = _mapper.Map<KategoriDTO>(kategori);

                return Ok(result);
            }
            else
            {
                return BadRequest("Hatalı Talep");
            }
        }

        //    Güncelleme için kullanılır.Kısmi güncelleme olarak değerlendirilir.


        //[HttpPatch]
        // public KategoriDTO Patch([FromBody] KategoriDTO dto)
        // {
        //     Kategori kat = _mapper.Map<Kategori>(dto);
        //     Kategori kategori = _kategoriBS.Update(kat);

        //     KategoriDTO result = _mapper.Map<KategoriDTO>(kategori);

        //     return result;
        // }


        [HttpDelete("{id}")]
        // Controller üzerinde yazılı olan route yapısına action metot a verdiğim route yapısı
        public IActionResult Delete(int id)
        {
            _kategoriBS.DeleteById(id);

            return Ok("Silme Başarılı");
        }



        //Informational responses(100 – 199)
        //Successful responses(200 – 299)
        //Redirection messages(300 – 399)
        //Client error responses(400 – 499)
        //Server error responses(500 – 599)
    }
}
