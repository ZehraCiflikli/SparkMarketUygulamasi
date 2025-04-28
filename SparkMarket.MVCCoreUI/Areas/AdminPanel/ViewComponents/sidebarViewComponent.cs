using Infrastructure.Enumarations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class sidebarViewComponent : ViewComponent
    {

        IMenuBS _menuBS;
        ISessionManager _session;
        IKullaniciBS _kullaniciBs;
        IMemoryCache _cache;
        public sidebarViewComponent(IMenuBS menuBs, ISessionManager session, IKullaniciBS kullaniciBs, IMemoryCache cache)
        {

            _menuBS = menuBs;
            _session = session;
            _kullaniciBs = kullaniciBs;
            _cache = cache;

        }

        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IViewComponentResult Invoke()
        {
            List<Menu> menu = new List<Menu>();
            //if (_cache.TryGetValue("Menu", out menu))
            //{

            //}
            //else
            //{
            menu = _menuBS.GetAll(filter: x => x.Aktif == true, orderby: x => x.Sira, sorted: Sorted.ASC, Tracking: false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");

            //    _cache.Set<List<Menu>>("Menu", menu,new DateTimeOffset(DateTime.Now.AddSeconds(60)));

            //}

            //  menu.Where(x => x.UstMenuId == null); // Ana Menülerim

            SideBarViewModel model = new SideBarViewModel();
            model.Menuler = menu;


            // Aktif Kullanıcının Rolleri
            //  _session.AktifYonetici.KullaniciRols;

            // Menünün 


            return View(model);
        }





    }
}
