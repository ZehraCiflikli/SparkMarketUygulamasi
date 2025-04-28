using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.Statics;
using SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers;
using SparkMarket.MVCCoreUI.Extensions;

namespace SparkMarket.MVCCoreUI.Filters
{
    public class SessionManager : ISessionManager
    {

        IHttpContextAccessor _httpContextAccessor;
        private readonly IKullaniciBS _kullaniciBS;
        IMenuBS _menuBS;
        public SessionManager(IHttpContextAccessor httpContextAccessor, IKullaniciBS kullaniciBS, IMenuBS menuBS)
        {
            _httpContextAccessor = httpContextAccessor;
            _kullaniciBS = kullaniciBS;
            _menuBS = menuBS;

        }
        public Kullanici AktifKullanici
        {
            get
            {

                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifKullanici, value);

            }
        }
        public Kullanici AktifYonetici
        {


            get
            {

                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifYonetici);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifYonetici, value);

            }



        }

        public string GuvenlikKodu
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<string>(SessionKeys.GuvenlikKodu);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.GuvenlikKodu, value);

            }
        }

        public List<Dosya> Dosyalar
        {


            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<List<Dosya>>(SessionKeys.Dosyalar);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.Dosyalar, value);

            }


        }

        public bool YetkisiVarmi(int MenuId, int KullaniciId)
        {
            Menu menu = _menuBS.Get(x => x.Id == MenuId, false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");

            Kullanici k = _kullaniciBS.Get(x => x.Id == KullaniciId, false, "KullaniciRols");

            bool yetki = false;

            foreach (MenuYetki myetki in menu.MenuYetkis)
            {

                foreach (KullaniciRol krol in k.KullaniciRols)
                {

                    if (myetki.SelectYetki == true && myetki.RolId == krol.RolId)
                    {
                        yetki = true;

                        break;
                    }
                }

            }


            return yetki;
        }
    }
}
