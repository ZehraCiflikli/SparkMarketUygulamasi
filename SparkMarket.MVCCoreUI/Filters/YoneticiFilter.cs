using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.Statics;
using SparkMarket.MVCCoreUI.Extensions;

namespace SparkMarket.MVCCoreUI.Filters
{
    public class YoneticiFilter : ActionFilterAttribute
    {




        public override void OnActionExecuting(ActionExecutingContext context)
        {


         





            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifYonetici);
            if (kullanici == null)
            {

                context.Result = new RedirectResult("/AdminPanel/Yonetici/Login");

            }



            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
