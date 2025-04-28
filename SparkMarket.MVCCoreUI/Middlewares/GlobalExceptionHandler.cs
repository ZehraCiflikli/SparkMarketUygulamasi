using System.Text;

namespace SparkMarket.MVCCoreUI.Middlewares
{
    public class GlobalExceptionHandler
    {

        private readonly RequestDelegate _next;
        private readonly string _filename;
        public GlobalExceptionHandler(RequestDelegate next, string filename)
        {
            _next = next;
            _filename = filename;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            // Request bölümü Bir sonraki middlware geçmeden önce kod yazabilirsin

            //-------------------

            try
            {
                // Bu miidlewareden cont gidene kadar ve controlerdan bu middleware gelene kadar hata oldumu

                HttpRequest request = context.Request;

                await _next(context);

                HttpResponse response = context.Response;

            }
            catch (Exception ex)
            {

                HandleExceptionAsync(context, ex);

            }


            // Response bölümü
            //-------------------


        }

        private async void HandleExceptionAsync(HttpContext context, Exception ex)
        {

            //string path = context.Request.Path;
            //string method = context.Request.Method;
            // context.Response.StatusCode
            // QueryString querystring = context.Request.QueryString;
            // context.Request.Headers;
            // context.Request.Body;
            // & Hata yı logla 

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Hata Tarihi:" + DateTime.Now + " Hata Mesajı :" + ex.Message);
            await File.AppendAllTextAsync(_filename, sb.ToString());


        }
    }
}
