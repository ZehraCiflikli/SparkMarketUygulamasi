using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MenuController : Controller
    {
        private readonly IMenuBS _menuBS;
        public MenuController(IMenuBS menuBS)
        {
            _menuBS = menuBS;
        }




        public IActionResult Index()
        {

            MenuIndexViewModel model = new MenuIndexViewModel();

            List<Menu> menuler = _menuBS.GetAll();

            model.UstMenuListe = menuler.Select(x => new SelectListItem() { Text = x.UstMenuGorunum, Value = x.Id.ToString() }).ToList();

            model.UstMenuListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Menüyü Seçiniz", Value = "0" });


            return View(model);
        }







        [HttpPost]
        public IActionResult List()
        {

            List<Menu> menuler = _menuBS.GetAll();

            return Json(new { data = menuler });
        }



        public IActionResult Add(IFormCollection data)
        {

            Menu m = new Menu();
            m.Baslik = data["Baslik"];
            m.Aciklama = data["Aciklama"]; // İçinde html kodları var
            m.UstMenuId = Convert.ToInt32(data["UstMenuId"]);
            m.Url = data["Url"];
            m.Sira = Convert.ToInt32(data["Sira"]);


            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
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

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/menu/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        m.MenuIcon = "/images/menu/" + newFileName;
                    }
                }

            }


            if (m.UstMenuId == 0)
            {

                m.UstMenuGorunum = m.Baslik;
                m.UstMenuId = null;

            }
            else
            {

                Menu ustMenu = _menuBS.Get(x => x.Id == m.UstMenuId);

                m.UstMenuGorunum = ustMenu.UstMenuGorunum + " >> " + m.Baslik;
            }

            _menuBS.Insert(m);


            //--------------MODAL İÇİN-----------------------

            List<Menu> menuler = _menuBS.GetAll();

            MenuIndexViewModel model = new MenuIndexViewModel();


            model.UstMenuListe = menuler.Select(x => new SelectListItem() { Text = x.UstMenuGorunum, Value = x.Id.ToString() }).ToList();

            model.UstMenuListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Menü Seçiniz", Value = "0", Selected = true });


            return Json(new { result = true, mesaj = "Menü Başasıyla Eklendi", model = model });
        }



        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);

            Menu m = _menuBS.Get(x => x.Id == Id);

            m.Baslik = data["Baslik"];
            m.Aciklama = data["Aciklama"]; // İçinde html kodları var
           m.Url = data["url"];
            m.Sira = Convert.ToInt32(data["sira"]);

            if (string.IsNullOrEmpty(data["UstMenuId"].ToString()))
            {
                m.UstMenuId = Convert.ToInt32(data["UstMenuId"]);
            }
            else
            {
                m.UstMenuId = 0;
            }

            


            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
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

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/menu/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        m.MenuIcon = "/images/menu/" + newFileName;
                    }
                }

            }

            if (m.UstMenuId == 0)
            {
                m.UstMenuGorunum = m.Baslik;
                m.UstMenuId = null;
            }
            else
            {

                Menu ustMenu = _menuBS.Get(x => x.Id == m.UstMenuId);

                m.UstMenuGorunum = ustMenu.UstMenuGorunum + " >> " + m.Baslik;
            }

            _menuBS.Update(m);


            List<Menu> menuler = _menuBS.GetAll();

            MenuIndexViewModel model = new MenuIndexViewModel();


            model.UstMenuListe = menuler.Select(x => new SelectListItem() { Text = x.UstMenuGorunum, Value = x.Id.ToString() }).ToList();



            if (m.UstMenuId == 0)
            {
                model.UstMenuListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Menü Seçiniz", Value = "0", Selected = true });
            }
            else
            {
                model.UstMenuListe.Insert(0, new SelectListItem() { Text = "Lütfen Üst Menü Seçiniz", Value = "0" });
            }
            
            model.Menu = m;



           

           
            return Json(new { result = true, mesaj = "Menü Başasıyla Güncellendi", model = model });
        }








        public IActionResult AktifPasif(int id, bool aktif)
        {
            Menu m = _menuBS.Get(x => x.Id == id);
            m.Aktif = aktif;
            _menuBS.Update(m);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }



        [HttpPost]
        public IActionResult GetMenu(int id)
        {

            Menu m = _menuBS.Get(x => x.Id == id);


            return Json(new { result = true, model = m });

        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            Menu m = _menuBS.Get(x => x.Id == id);

            _menuBS.Delete(m);

            return Json(new { result = true });


        }


       

        









    }
}
