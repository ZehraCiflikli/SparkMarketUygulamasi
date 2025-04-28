using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.ViewModel.Front;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
    public class signupViewComponent : ViewComponent
    {

        IIlBS _ilbs;
        public signupViewComponent(IIlBS ilbs)
        {
          _ilbs = ilbs;   
        }

        public IViewComponentResult Invoke()
        {

     

 System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");

            KullniciSignupVm model = new KullniciSignupVm();
            model.Sehirler = _ilbs.GetAll().Select(x => new SelectListItem() { Text = x.IlAdi, Value = x.Id.ToString() }).ToList() ;

            model.Sehirler.Insert(0, new SelectListItem() { Text = "Lütfen Şehir Seçiniz", Value = "0" });


            return View(model);
        }
    }
}
