using System.Text;
using System.Text.Json;

namespace SparkMarket.MVCCoreUI.Middlewares
{
    public class RequestResponseLogHandler
    {

        private readonly RequestDelegate _next;
        public RequestResponseLogHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            // Request'i yakala ve JSON olarak sakla
            context.Request.EnableBuffering(); // Request body'nin birden fazla okunmasını sağlar.
            var requestBody = await ReadStreamAsync(context.Request.Body);
            var requestLog = new
            {
                Method = context.Request.Method,
                Path = context.Request.Path,
                Headers = context.Request.Headers,
                Body = requestBody,
                RequestDate = DateTime.Now
            };

            var requestJson = JsonSerializer.Serialize(requestLog);
            LogRequest(requestJson); // Kendi loglama mekanizmanızı kullanın.

            // Response'u yakala ve JSON olarak sakla
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context); // Pipeline'daki diğer middleware'leri çağır.

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await ReadStreamAsync(context.Response.Body);


            var responseLog = new
            {
                StatusCode = context.Response.StatusCode,
                Headers = context.Response.Headers,
                Body = responseBodyText,
                ResponseDate = DateTime.Now
            };

            var responseJson = JsonSerializer.Serialize(responseLog);
            LogResponse(responseJson); // Kendi loglama mekanizmanızı kullanın.

            // Orijinal response'u geri döndür
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> ReadStreamAsync(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
            var text = await reader.ReadToEndAsync();
            stream.Seek(0, SeekOrigin.Begin);
            return text;
        }

        private void LogRequest(string json)
        {
            // Burada JSON'u dosyaya yazabilir, bir veri tabanına kaydedebilir veya başka bir yere gönderebilirsiniz.

        }

        private void LogResponse(string json)
        {
            // Burada JSON'u dosyaya yazabilir, bir veri tabanına kaydedebilir veya başka bir yere gönderebilirsiniz.

        }



    }
}
