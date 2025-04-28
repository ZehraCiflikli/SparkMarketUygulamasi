using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.Statics;
using SparkMarket.MVCCoreUI.Extensions;

namespace SparkMarket.MVCCoreUI.Filters
{
    public class MenuFilter : ActionFilterAttribute
    {

        // Filter larda cons. üzerinden depedecy injection ile nesne almak bize farklı sorunlar çıkarırır.

        // Bu nedenle context.HttpContext.RequestServices.GetService(typeof(IMenuBS)) yapısı üzerinden dependency yapısı kullanılır
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            string path = context.HttpContext.Request.Path.Value ?? "";

            IMenuBS _menuBs = (IMenuBS)context.HttpContext.RequestServices.GetService(typeof(IMenuBS));

            Menu menu = _menuBs.Get(x => x.Url == path, false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");

            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifYonetici);


            bool Allowed = false;
            foreach (MenuYetki myetki in menu.MenuYetkis)
            {

                foreach (KullaniciRol krol in kullanici.KullaniciRols)
                {

                    if (myetki.SelectYetki == true && myetki.RolId == krol.RolId)
                    {
                        Allowed = true;

                        break;
                    }
                }

            }

            if (!Allowed)
            {
                // İzin Yoksa

                context.Result = new RedirectResult("/AdminPanel/Yonetici/YetkinizYok");


            }

            base.OnActionExecuting(context);
        }

    }
}
