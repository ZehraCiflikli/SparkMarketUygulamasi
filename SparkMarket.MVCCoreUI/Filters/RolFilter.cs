using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.Statics;
using SparkMarket.MVCCoreUI.Extensions;

namespace SparkMarket.MVCCoreUI.Filters
{
    public class RolFilter : ActionFilterAttribute
    {


        private string[] _allowedRols;

        public RolFilter(params string[] allowedRols)
        {
            _allowedRols = allowedRols;

        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {


      

            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifYonetici);

            bool Allowed = false;


            foreach (KullaniciRol rol in kullanici.KullaniciRols)
            {

                foreach (string item in _allowedRols)
                {
                    if (rol.Rol.RolAdi == item)
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
