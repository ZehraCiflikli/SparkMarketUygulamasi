using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MenuYetkiController : Controller
    {
        IMenuBS _menuBS;
        IRolBS _rolBS;
        IMenuYetkiBS _menuYetkiBS;
        public MenuYetkiController(IMenuBS menuBS,
        IRolBS rolBS,
        IMenuYetkiBS menuYetkiBS)
        {
            _menuBS = menuBS;
            _rolBS = rolBS;
            _menuYetkiBS = menuYetkiBS;

        }

        public IActionResult Index()
        {
            MenuYetkiViewModel model = new MenuYetkiViewModel();
            model.MenuList = _menuBS.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.Baslik, Value = x.Id.ToString() }).ToList();

            model.MenuList.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen Seçiniz", Value = "0" });


            model.RolList = _rolBS.GetAll(x => x.Aktif == true).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.RolAdi, Value = x.Id.ToString() }).ToList();

            model.RolList.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lütfen Seçiniz", Value = "0" });

            model.MenuYetkiler = _menuYetkiBS.GetAll(x => x.Aktif == true, includelist: ["Menu", "Rol"])
                                      .Select(x => new MenuYetki
                                      {
                                          Menu = x.Menu,
                                          Rol = x.Rol,
                                          MenuId = x.MenuId,
                                          RolId = x.RolId,
                                           SelectYetki = x.SelectYetki ?? false,
                                          InsertYetki = x.InsertYetki ?? false,
                                          UpdateYetki = x.UpdateYetki ?? false,
                                          DeleteYetki = x.DeleteYetki ?? false
                                      }).ToList();

            // Eğer listede hiç öğe yoksa, boş bir liste de olabilir
            if (model.MenuYetkiler == null)
            {
                model.MenuYetkiler = new List<MenuYetki>();
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Save(MenuYetkiViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Seçilen menü ve rol ID'lerini al
                int secilenMenuId = model.MenuId.HasValue ? model.MenuId.Value : 0;
                int secilenRolId = model.RolId.HasValue ? model.RolId.Value : 0;




                // Seçilen yetkileri al
                bool selectYetki = model.SelectYetki ? model.SelectYetki : false;
                bool insertYetki = model.InsertYetki ? model.InsertYetki : false;
                bool updateYetki = model.UpdateYetki ? model.UpdateYetki : false;
                bool deleteYetki = model.DeleteYetki ? model.DeleteYetki : false;


                // Yetkileri kaydetme veya güncelleme işlemi
                YetkileriKaydet(secilenMenuId, secilenRolId, selectYetki, insertYetki, updateYetki, deleteYetki);

                // İşlem başarılıysa başka bir sayfaya yönlendir
                return Json(new { result = true, mesaj = "Yetkiler Güncellendi" });
            }
            else
            {
                return Json(new { result = false, mesaj = "Lütfen Seçim Yapınız" });
            }





        }

        [HttpPost]
        public IActionResult GetMenuYetki(int menuId, int rolId)
        {

            var menuYetki = _menuYetkiBS.Get((y => y.MenuId == menuId && y.RolId == rolId));


            return Json(new { result = true, model = menuYetki });

        }

        private void YetkileriKaydet(int menuId, int rolId, bool selectYetki, bool insertYetki, bool updateYetki, bool deleteYetki)
        {
            // Veritabanında bu menü ve rol için yetki var mı kontrol et
            var menuYetki = _menuYetkiBS.Get((y => y.MenuId == menuId && y.RolId == rolId));

            if (menuYetki == null)
            {
                // Yetki yoksa yeni bir yetki oluştur
                menuYetki = new MenuYetki
                {
                    MenuId = menuId,
                    RolId = rolId,
                    SelectYetki = selectYetki,
                    InsertYetki = insertYetki,
                    UpdateYetki = updateYetki,
                    DeleteYetki = deleteYetki,
                    Aktif=true,
                };
                _menuYetkiBS.Insert(menuYetki);
            }
            else
            {
                // Yetki varsa güncelle
                menuYetki.SelectYetki = selectYetki;
                menuYetki.InsertYetki = insertYetki;
                menuYetki.UpdateYetki = updateYetki;
                menuYetki.DeleteYetki = deleteYetki;
             
                // Değişiklikleri kaydet
                _menuYetkiBS.Update(menuYetki);

            }

        }
    }
}
