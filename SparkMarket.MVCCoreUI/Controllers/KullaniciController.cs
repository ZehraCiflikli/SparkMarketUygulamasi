using AutoMapper;
using Infrastructure.CrossCuttingConcern.Comunication;
using Infrastructure.CrossCuttingConcern.Crypto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Front;
using System.Configuration;
using System.Net.Mail;

namespace SparkMarket.MVCCoreUI.Controllers
{
    public class KullaniciController : Controller
    {

        IKullaniciBS _kullaniciBS;
        IMapper _mapper;
        MailIslemleri _mailIslemleri;
        IConfiguration _conf;
    
        public KullaniciController(IKullaniciBS kullaniciBS, IMapper mapper, MailIslemleri mailIslemleri, IConfiguration conf)
        {
            _kullaniciBS = kullaniciBS;
            _mapper = mapper;
            _mailIslemleri = mailIslemleri;
            _conf = conf;
          
        }



        public IActionResult Login()
        {


         

            return View();
        }


        [HttpPost]
        public IActionResult Add(KullniciSignupVm vm)
        {


            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList();

                return Json(new { result = false, errors = errors, mesaj = "Bilgilerinizi Kontrol Ediniz" });
            }


            Kullanici kullanici = _mapper.Map<Kullanici>(vm);
            //kullanici.Sifre = CryptoManager.SHA256Encrypt(vm.Sifre);
            kullanici.Sifre = CryptoManager.AESEncrypt(vm.Sifre, "SparkMarketKey");
            kullanici.UniqueId = Guid.NewGuid();
            kullanici.Aktif = false;
            kullanici.Durum = 0;


            kullanici = _kullaniciBS.Insert(kullanici);

            // Mail Gönderme İşlemi Yapılacak.
            string website = _conf.GetSection("websitehost").Value;
            //mailIslemleri.Send(kullanici.Email, "SparkMarket", "Merhaba " + kullanici.Adi + " SparkMarkete  hoşgeldiniz <br><a href='" + website + "/Kullanici/EmailOnay/" + kullanici.UniqueId + "'> Lütfen emailinizi onaylamak için tıklayınız.</a>");

            // Mail Atarak Mail Onay İşlemi Yapılacak
            return Json(new { result = true, mesaj = "Kayıt Başarılı" });


        }



        public IActionResult EmailOnay(Guid id)
        {

            Kullanici k = _kullaniciBS.Get(x => x.UniqueId == id);

            if (k == null)
            {

                return RedirectToAction("EmailOnay", "Kullanici");// ??????


            }
            else
            {
                k.Aktif = true;
                k.Durum = 1;
                k.UniqueId = Guid.NewGuid();

                _kullaniciBS.Update(k);

                return View();
            }




        }
        public IActionResult YetkisizIslem()
        {

            return View();
        }


    }
}
