using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Front;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Controllers
{
    public class OdemeAlController : Controller
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
        ISepetBS _sepetBS;
        IKullaniciBS _kullaniciBS;
        public OdemeAlController(IUrunBS urunBS,
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
         ISepetBS sepetBS,
         IKullaniciBS kullaniciBS,
        IUrunResimBS urunResimBS
            )
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
            _sepetBS = sepetBS;
            _kullaniciBS = kullaniciBS;

            // BURADA LOGİN SAYFASI YAPILMADIĞI İÇİN SESSİON ELLE DOLDURULDU.
            // _session.AktifKullanici = kullaniciBS.GetById(2);
        }

        public IActionResult Index()
        {
            OdemeModel model = new OdemeModel();
            int id = _session.AktifKullanici.Id;
            List<Sepet> sepetler = _sepetBS.GetAll(x => x.KullaniciId == id, includelist: ["Kullanici", "Urun", "Urun.UrunResims", "Urun.UrunFiyats"]);


            decimal toplamTutar = 0;
            foreach (var item in sepetler)
            {
                toplamTutar += item.Urun.UrunFiyats.SingleOrDefault(x => x.FiyatTipiId == 4).UrunFiyati.Value * item.Adet.Value;
            }


            model.Ad = _session.AktifKullanici.Adi;
            model.Soyad = _session.AktifKullanici.Soyadi;
            model.Tutar = toplamTutar;




            return View(model);
        }
        [HttpPost]
        public ActionResult OdemeYap(OdemeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                // iyzico için gerekli Options sınıfı tanımlanıyor
                Options options = new Options
                {
                    ApiKey = "SIZIN_API_KEY",
                    SecretKey = "SIZIN_SECRET_KEY",
                    BaseUrl = "https://sandbox-api.iyzipay.com"
                    // Canlı ortam için: "https://api.iyzipay.com"
                };

                // Ödeme nesnesini oluştur
                CreatePaymentRequest request = new CreatePaymentRequest
                {
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString(),
                    Price = model.Tutar.ToString().Replace(",", "."),
                    PaidPrice = model.Tutar.ToString().Replace(",", "."),
                    Currency = Currency.TRY.ToString(),
                    Installment = 1,
                    BasketId = "B" + DateTime.Now.Ticks,
                    PaymentChannel = PaymentChannel.WEB.ToString(),
                    PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                    CallbackUrl = "https://www.siteniz.com/odeme/sonuc"
                };

                // Ödeme kartı bilgileri
                PaymentCard paymentCard = new PaymentCard
                {
                    CardHolderName = model.KartSahibi,
                    CardNumber = model.KartNumarasi,
                    ExpireMonth = model.SonKullanmaAy,
                    ExpireYear = model.SonKullanmaYil,
                    Cvc = model.Cvc,
                    RegisterCard = 0
                };
                request.PaymentCard = paymentCard;

                // Alıcı bilgileri
                Buyer buyer = new Buyer
                {
                    Id = "BY789",
                    Name = model.Ad,
                    Surname = model.Soyad,
                    GsmNumber = model.Telefon,
                    Email = model.Email,
                    IdentityNumber = "74300864791",
                    RegistrationAddress = model.Adres,
                    Ip = Request.Host.Value[0].ToString(),
                    City = model.Sehir,
                    Country = "Turkey"
                };
                request.Buyer = buyer;

                // Teslimat adresi
                Address shippingAddress = new Address
                {
                    ContactName = model.Ad + " " + model.Soyad,
                    City = model.Sehir,
                    Country = "Turkey",
                    Description = model.Adres
                };
                request.ShippingAddress = shippingAddress;

                // Fatura adresi
                Address billingAddress = new Address
                {
                    ContactName = model.Ad + " " + model.Soyad,
                    City = model.Sehir,
                    Country = "Turkey",
                    Description = model.Adres
                };
                request.BillingAddress = billingAddress;

                // Sepet ürünleri
                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem basketItem = new BasketItem
                {
                    Id = "BI101",
                    Name = "Örnek Ürün",
                    Category1 = "Kategori",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = model.Tutar.ToString().Replace(",", ".")
                };
                basketItems.Add(basketItem);
                request.BasketItems = basketItems;

                // Ödeme işlemini başlat
                Payment payment = Payment.Create(request, options).Result;

                if (payment.Status == "success")
                {
                    // Ödeme başarılı ise
                    ViewBag.Message = "Ödeme başarıyla gerçekleştirildi.";
                    ViewBag.PaymentId = payment.PaymentId;
                    return View("Success");
                }
                else
                {
                    // Ödeme başarısız ise
                    ViewBag.ErrorMessage = payment.ErrorMessage;
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ödeme işlemi sırasında bir hata oluştu: " + ex.Message;
                return View("Error");
            }
        }

        // Ödeme sonucu
        public ActionResult Sonuc()
        {
            //string paymentId = Request.QueryString["paymentId"];
            // Burada ödeme durumunu kontrol etmek için 
            // RetrievePayment API'sini kullanabilirsiniz

            // SepetId

            // Siparişlere Ekle
            // Sepetin Tamamını Sil.



            return View();
        }

    }
}
