using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class RolController : Controller
    {

        private readonly IRolBS _rolBS;

        public RolController(IRolBS rolBS)
        {
            _rolBS = rolBS;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult List()
        {
            List<Rol> r = _rolBS.GetAll();

            return Json(new { data = r });
        }


        [HttpPost]
        public IActionResult Add(RolIndexViewModel r)
        {
            Rol rol = new Rol();
            rol.RolAdi = r.RolAdi;

            _rolBS.Insert(rol);

            return Json(new { result = true, mesaj = "Rol Başasıyla Eklendi" });

        }


        public IActionResult AktifPasif(int id, bool aktif)
        {
            Rol rol = _rolBS.Get(x => x.Id == id);
            rol.Aktif = aktif;
            _rolBS.Update(rol);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }



        [HttpPost]
        public IActionResult GetRol(int id)
        {


            Rol rol = _rolBS.Get(x => x.Id == id);

            return Json(new { result = true, model = rol });

        }


        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Rol rol = _rolBS.Get(x => x.Id == Id);


            rol.RolAdi = data["RolAdi"];

            _rolBS.Update(rol);



            return Json(new { result = true, mesaj = "Rol Başasıyla Güncellendi" });
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            Rol rol = _rolBS.Get(x => x.Id == id);

            _rolBS.Delete(rol);

            return Json(new { result = true });


        }


    }
}
