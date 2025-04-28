using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Front;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Controllers
{
    public class SepetController : Controller
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
        public SepetController(IUrunBS urunBS,
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
            _session.AktifKullanici = kullaniciBS.GetById(2);


        }


        public IActionResult Index()
        {

            List<Sepet> sepet = _sepetBS.GetAll(includelist: ["Kullanici", "Urun", "Urun.UrunResims", "Urun.UrunFiyats"]);

            SepetViewModel model = new SepetViewModel();
            model.SepetUrunleri = sepet;
            decimal toplamTutar = 0;
            foreach (var item in model.SepetUrunleri)
            {
                toplamTutar += item.Urun.UrunFiyats.SingleOrDefault(x => x.FiyatTipiId == 4).UrunFiyati.Value * item.Adet.Value;
            }

            model.ToplamTutar = toplamTutar;
            return View(model);
        }

        public IActionResult Add(int id)
        {
            int kid = _session.AktifKullanici.Id;
            Sepet s = _sepetBS.Get(x => x.UrunId == id && x.KullaniciId == kid);
            if (s == null)
            {
                Urun urun = _urunBS.GetById(id);
                Sepet sep = new Sepet();
                sep.Aktif = true;
                sep.Adet = 1;
                sep.KullaniciId = kid;
                sep.UrunId = urun.Id;
                _sepetBS.Insert(sep);
            }
            else
            {
                s.Aktif = true;
                s.Adet = s.Adet + 1;
                _sepetBS.Update(s);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SepetArtir(int id)
        {
            int kid = _session.AktifKullanici.Id;
            Sepet s = _sepetBS.Get(x => x.UrunId == id && x.KullaniciId == kid);
            if (s == null)
            {
                Urun urun = _urunBS.GetById(id);
                Sepet sep = new Sepet();
                sep.Aktif = true;
                sep.Adet = 1;
                sep.KullaniciId = kid;
                sep.UrunId = urun.Id;
                _sepetBS.Insert(sep);
            }
            else
            {
                s.Aktif = true;
                s.Adet = s.Adet + 1;
                _sepetBS.Update(s);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SepetAzalt(int id)
        {
            int kid = _session.AktifKullanici.Id;
            Sepet s = _sepetBS.Get(x => x.UrunId == id && x.KullaniciId == kid);

            s.Aktif = true;
            if (s.Adet - 1 == 0)
            {
                _sepetBS.Delete(s);

            }
            else
            {
                s.Adet = s.Adet - 1;
                _sepetBS.Update(s);
            }


            return RedirectToAction("Index");
        }

        public IActionResult SepetSil(int id)
        {
            int kid = _session.AktifKullanici.Id;
            Sepet s = _sepetBS.Get(x => x.UrunId == id && x.KullaniciId == kid);

            if (s!=null)
            {
                _sepetBS.Delete(s);
            }


            return RedirectToAction("Index");
        }
    }
}
