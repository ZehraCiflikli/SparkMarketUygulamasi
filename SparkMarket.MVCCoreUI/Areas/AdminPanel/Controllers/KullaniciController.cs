using AutoMapper;
using Infrastructure.Enumarations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class KullaniciController : Controller
    {
        private readonly IIlceBS ilceBS;
        private readonly IIlBS ilBs;
        private readonly IMapper mapper;
        private readonly IKullaniciTipiBS kullaniciTipiBS;
        private readonly IKullaniciBS kullaniciBS;
        private readonly IRolBS rolBS;
        private readonly IKullaniciRolBS kullaniciRolBS;
        private readonly IKullaniciAdreBS kullaniciAdreBS;
        private readonly IKullaniciKurumsalBS kullaniciKurumsalBS;
        public KullaniciController(IKullaniciBS kullaniciBS, IRolBS rolBS, IKullaniciTipiBS kullaniciTipiBS, IMapper mapper, IKullaniciRolBS kullaniciRolBS, IKullaniciAdreBS kullaniciAdreBS, IKullaniciKurumsalBS kullaniciKurumsalBS, IIlBS ilBs, IIlceBS ilceBS)
        {
            this.kullaniciTipiBS = kullaniciTipiBS;
            this.kullaniciBS = kullaniciBS;
            this.rolBS = rolBS;
            this.mapper = mapper;
            this.kullaniciRolBS = kullaniciRolBS;
            this.kullaniciAdreBS = kullaniciAdreBS;
            this.kullaniciKurumsalBS = kullaniciKurumsalBS;
            this.ilBs = ilBs;
            this.ilceBS = ilceBS;
        }

        public IActionResult Index()
        {
            KullaniciVm model = new KullaniciVm();
            model.KullaniciTipleri = kullaniciTipiBS.GetAll().Select(x => new SelectListItem() { Text = x.KullaniciTipiAdi, Value = x.Id.ToString() }).ToList();
            return View(model);
        }
        public IActionResult Add(KullaniciVm vm)
        {
            Kullanici kullanici = mapper.Map<Kullanici>(vm);
            kullanici.UniqueId = Guid.NewGuid();
            kullanici.Aktif = true;
            
            if (vm.KullaniciTipi == 0)
            {
                kullanici.KullaniciTipi = null;
            }
            kullaniciBS.Insert(kullanici);

            return Json(new { result = true, mesaj = "Kullanıcı basarıyla eklendi." });
        }
        public IActionResult Delete(int id)
        {
            List<KullaniciAdre> adresler = kullaniciAdreBS.GetAll(x => x.KullaniciId == id);
            List<KullaniciKurumsal> kurumsals = kullaniciKurumsalBS.GetAll(x => x.KullaniciId == id);
            List<KullaniciRol> kroller = kullaniciRolBS.GetAll(x => x.KullaniciId == id);
            for (int i = 0; i < kroller.Count(); i++)
            {
                kullaniciRolBS.Delete(kroller[i]);
            }
            for (int i = 0; i < adresler.Count(); i++)
            {
                kullaniciAdreBS.Delete(adresler[i]);
            }
            for (int i = 0; i < kurumsals.Count(); i++)
            {
                kullaniciKurumsalBS.Delete(kurumsals[i]);
            }
            kullaniciBS.DeleteById(id);

            return Json(new { result = true, mesaj = "Kullanici basarıyla silindi." });
        }
        public IActionResult RolModal(int id)
        {
            Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciRols", "KullaniciRols.Rol"]);

            List<Rol> roller = rolBS.GetAll();

            KullaniciRolVm model = new KullaniciRolVm();
            model.KullaniciId = id;
            model.Roller = roller.Select(x => new SelectListItem() { Text = x.RolAdi, Value = x.Id.ToString(), Selected = kullanici.KullaniciRols.Select(x => x.RolId).Contains(x.Id) ? true : false }).ToList();

            return PartialView("RolModalPartial", model);
        }
        public IActionResult RolGuncelle(KullaniciRolVm vm)
        {
            List<KullaniciRol> kullaniciRol = kullaniciRolBS.GetAll(x => x.KullaniciId == vm.KullaniciId);
            foreach (KullaniciRol item in kullaniciRol)
            {
                kullaniciRolBS.Delete(item);
            }
            if (vm.RolIds != null)
            {
                foreach (int item in vm.RolIds)
                {
                    kullaniciRolBS.Insert(new KullaniciRol() { KullaniciId = vm.KullaniciId, RolId = item });
                }
            }

            return Json(new { result = true, mesaj = "Kullanici Roller basarıyla güncellendi" });
        }
        public IActionResult ChangeAktif(int id, bool deger)
        {
            Kullanici kullanici = kullaniciBS.GetById(id);
            kullanici.Aktif = deger;
            kullaniciBS.Update(kullanici);
            return Json(new { result = true, mesaj = "Aktiflik basarıyla güncellendi." });
        }
        public IActionResult DigerBilgiler(int id)
        {
            Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciAdres", "KullaniciTipiNavigation", "KullaniciKurumsals"]);          
            KullaniciDigerBilgilerVm model = mapper.Map<KullaniciDigerBilgilerVm>(kullanici);           
            KullaniciAdre adres = kullaniciAdreBS.GetAll(x => x.KullaniciId == id, includelist: ["Il", "Ilce"]).FirstOrDefault() ?? new KullaniciAdre();
            model.KullaniciAdresi = mapper.Map<KullaniciAdresVm>(adres);
            
            return PartialView("DigerBilgilerModal", model);
        }
        public IActionResult DigerBilgilerEditModal(int id)
        {
            Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciTipiNavigation","KullaniciKurumsals"]);
            KullaniciDigerBilgilerVm model = mapper.Map<KullaniciDigerBilgilerVm>(kullanici);           
            KullaniciAdre adres = kullaniciAdreBS.GetAll(x => x.KullaniciId == id).FirstOrDefault() ?? new KullaniciAdre();          
            model.KullaniciAdresi = mapper.Map<KullaniciAdresVm>(adres);
            
            model.Sehirler = ilBs.GetAll().Select(x => new SelectListItem() { Text = x.IlAdi, Value = x.Id.ToString(), Selected = adres.IlId == x.Id ? true : false }).ToList();
            model.Semtler = ilceBS.GetAll().Select(x => new SelectListItem() { Text = x.IlceAdi, Value = x.Id.ToString(), Selected = adres.IlceId == x.Id ? true : false }).ToList();
            model.KullaniciTipleri = kullaniciTipiBS.GetAll(x => x.Aktif == true).Select(x => new SelectListItem() { Text = x.KullaniciTipiAdi, Value = x.Id.ToString(), Selected = kullanici.KullaniciTipi == x.Id ? true : false }).ToList();
            
            return PartialView("DigerBilgilerEditModal", model);
        }
        public IActionResult UpdateDigerBilgiler(KullaniciDigerBilgilerVm vm)
        {
            Kullanici kullanici = kullaniciBS.Get(x => x.Id == vm.KullaniciId, includelist: ["KullaniciAdres"]);
            kullanici.KullaniciTipi = vm.KullaniciTipiId == 0 ? null : vm.KullaniciTipiId;
            kullanici.TckimlikNo = vm.TckimlikNo;
            kullanici.CepTelefonu = vm.CepTelefonu;
            kullaniciBS.Update(kullanici);
            if (vm.KullaniciAdresi != null)
            {
                KullaniciAdre adres = kullanici.KullaniciAdres.FirstOrDefault();
                if (adres != null)
                {
                    adres.IlId = vm.KullaniciAdresi.SehirId;
                    adres.IlceId = vm.KullaniciAdresi.SemtId;
                    adres.Adres = vm.KullaniciAdresi.Adres;
                    kullaniciAdreBS.Update(adres);
                }
                else
                {
                    adres = new KullaniciAdre();
                    adres.KullaniciId = vm.KullaniciId;
                    adres.IlId = vm.KullaniciAdresi.SehirId;
                    adres.IlceId = vm.KullaniciAdresi.SemtId;
                    adres.Adres = vm.KullaniciAdresi.Adres;
                    kullaniciAdreBS.Insert(adres);
                }

            }
            Kullanici yenikullanici = kullaniciBS.Get(x => x.Id == vm.KullaniciId, includelist: ["KullaniciTipiNavigation"]);
            if (yenikullanici.KullaniciTipiNavigation != null && yenikullanici.KullaniciTipiNavigation.KullaniciTipiAdi == "Kurumsal")
            {
                KullaniciKurumsal kurumsal = kullaniciKurumsalBS.Get(x => x.KullaniciId == vm.KullaniciId);
                if (kurumsal != null)
                {
                    kurumsal.VergiNo = vm.VergiNo==0 ? null :vm.VergiNo;
                    kurumsal.VergiDairesi = vm.VergiDairesi;
                    kullaniciKurumsalBS.Update(kurumsal);
                }
                else
                {
                    kurumsal = new KullaniciKurumsal();

                    kurumsal.KullaniciId = vm.KullaniciId;
                    kurumsal.VergiNo = vm.VergiNo ?? 0;
                    kurumsal.VergiDairesi = vm.VergiDairesi ?? "";
                    kurumsal.Aktif = true;
                    kullaniciKurumsalBS.Insert(kurumsal);
                }
            }
            return Json(new { result = true, mesaj = "Bigiler basarıyla güncellendi" });
        }
        public IActionResult UpdateModal(int id)
        {
            Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciTipiNavigation"]);
            KullaniciVm model = mapper.Map<KullaniciVm>(kullanici);
            model.KullaniciTipleri = kullaniciTipiBS.GetAll().Select(x => new SelectListItem() { Text = x.KullaniciTipiAdi, Value = x.Id.ToString(), Selected = kullanici.KullaniciTipi == x.Id ? true : false }).ToList();
            return PartialView("UpdateModal", model);
        }
        public IActionResult Update(UpdateKullaniciVm vm)
        {
            Kullanici kullanici = kullaniciBS.GetById(vm.Id);
            kullanici.Adi = vm.Adi;
            kullanici.Soyadi = vm.Soyadi;
            kullanici.Email = vm.Email;
            kullanici.Sifre = vm.Sifre;
            kullaniciBS.Update(kullanici);

            return Json(new { result = true, mesaj = "Kullanici basarıyla güncellendi." });
        }
    }
}
