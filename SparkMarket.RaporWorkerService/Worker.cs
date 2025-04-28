using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SparkMarket.Model.DTO;
using SparkMarket.Model.Entity;
using System.Reflection.Metadata;
using System.Text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Channels;
namespace SparkMarket.RaporWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {



            return base.StartAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";


            // Connection Oluþturuldu
            IConnection con = factory.CreateConnectionAsync().Result;


            // Kanal Oluþturuldu
            IChannel channel = con.CreateChannelAsync().Result;

            channel.BasicQosAsync(0, 1, false); // Her consumer ýn kuyruktan 1 kerede  kaçar kaçar veri çekeceðini belirler.


            string queuename = "raporqueue";
            // Event Tanýmlama
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += VeriGeldi;

            // Veriyi Çekme
            channel.BasicConsumeAsync(queuename, true, consumer);


            //while (!stoppingToken.IsCancellationRequested)
            //{

            //   int gun =  DateTime.Now.Day;

            //    int saat = DateTime.Now.Hour;

            //    if (gun==15 && saat ==1)
            //    {

            //    }





            //    if (_logger.IsEnabled(LogLevel.Information))
            //    {
            //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    }
            //    await Task.Delay(1000, stoppingToken);
            //}
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {


            return base.StopAsync(cancellationToken);
        }
        private static async Task VeriGeldi(object sender, BasicDeliverEventArgs @event)
        {
            // RAPORU HAZIRLA
            // Raporu Hazýrlamak için gerekli olan verileri web api ile çek
            // Veriler 
            // Web Api 
            var body = @event.Body.ToArray();
            var mesaj = Encoding.UTF8.GetString(body);



            HttpClient client = new HttpClient();

            var response = client.GetAsync("http://localhost:5165/api/urun").Result;

            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;
                List<Urun> urunler = JsonConvert.DeserializeObject<List<Urun>>(result);

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 30f, 30f, 20f, 10f);

                MemoryStream output = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, output);
                doc.Open();

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);


                Font Baslik = new Font(STF_Helvetica_Turkish, 10f, Font.BOLD);
                Font AltBaslik = new Font(STF_Helvetica_Turkish, 10f, Font.NORMAL);
                Font Tablefont = new Font(STF_Helvetica_Turkish, 8f, Font.NORMAL);
                Font Tablefontbold = new Font(STF_Helvetica_Turkish, 8f, Font.BOLD);
                Font GovdeKucuk = new Font(STF_Helvetica_Turkish, 6f, Font.NORMAL);

                SatirEkle(doc);
                ParagrafEkle("ANA RAPOR BAÞLIÐI ", doc, AltBaslik, Element.ALIGN_CENTER, 5f);
                ParagrafEkle("ALT RAPOR BAÞLIÐI", doc, AltBaslik, Element.ALIGN_CENTER, 30f, 5f);
                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 100;
                // Set the relative widths of the columns
                float[] columnWidths = { 20f }; // First column will be half the width of the second column
                table.SetWidths(columnWidths);

                BaslikEkle("ÜRÜN LÝSTESÝ", table, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);

                // Add the table to the document
                doc.Add(table);

                PdfPTable tableHeader = new PdfPTable(6);
                tableHeader.WidthPercentage = 100;
                // Set the relative widths of the columns
                float[] columnWidthsHeader = { 8f, 10f, 20f, 36f, 8f, 8f }; // First column will be half the width of the second column
                tableHeader.SetWidths(columnWidthsHeader);

                BaslikEkle("ID", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
                BaslikEkle("ÜRÜN ADI", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
                BaslikEkle("AÇIKLAMA", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);

                // Add the table to the document
                doc.Add(tableHeader);

                #region alt tablo
                PdfPTable tablealt = new PdfPTable(6);
                tablealt.WidthPercentage = 100;

                float[] altcolumnWidths = { 8f, 10f, 20f, 36f, 8f, 8f }; // First column will be half the width of the second column
                tablealt.SetWidths(altcolumnWidths);

                foreach (var item in urunler)
                {
                    HucreEkle(item.Id.ToString(), tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);
                    HucreEkle(item.UrunAdi + "", tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);
                    HucreEkle(item.Aciklama, tablealt, Tablefont, 1, 1, Element.ALIGN_LEFT);

                }

                doc.Add(tablealt);
                #endregion

                doc.Close();

                byte[] raporbyte = output.ToArray();

                //MultipartFormDataContent multipartFormDataContent = new();

                //multipartFormDataContent.Add(new ByteArrayContent(raporbyte), "file", Guid.NewGuid().ToString() + ".pdf");

                using (var httpClient = new HttpClient())
                {

                    var content = new ByteArrayContent(raporbyte);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                    var responsepost = await httpClient.PostAsync("http://localhost:5165/api/urun?id=" + mesaj, content);

                    if (responsepost.IsSuccessStatusCode)
                    {




                        Console.WriteLine("Servis Çalýþtý.Rapor Web Apiye Gönderildi.");

                        //_channel.BasicAck(@event.DeliveryTag, false);
                    }
                }







            }


        }
        public static void HucreEkle(string icerik, PdfPTable table, Font Tablefont, int _colspan, int rowspan = 1, int align = Element.ALIGN_LEFT)
        {
            PdfPCell cell;
            Phrase p = new Phrase(icerik, Tablefont);
            cell = new PdfPCell(p);
            cell.Colspan = _colspan;
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = align;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.MinimumHeight = 20f;
            cell.BorderColor = new BaseColor(13, 198, 254);
            table.AddCell(cell);
        }
        public static void HtmlMetinEkle(string icerik, iTextSharp.text.Document doc, float AltBosluk = 0, float UstBosluk = 0)
        {
            if (!string.IsNullOrEmpty(icerik))
            {
                Paragraph bas1 = new Paragraph();
                bas1.Alignment = Element.ALIGN_CENTER;
                bas1.SpacingAfter = UstBosluk;
                doc.Add(bas1);


                TextReader readerOnMetin = new StringReader(icerik);

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                HTMLWorker worker = new HTMLWorker(doc);
                FontFactory.Register(Path.Combine("C:\\Windows\\Fonts\\Arial.ttf"), "Garamond");
                worker.StartDocument();
                StyleSheet css = new StyleSheet();
                css.LoadTagStyle("body", "face", "Garamond");
                css.LoadTagStyle("body", "encoding", "Identity-H");
                css.LoadTagStyle("body", "size", "12pt");
                worker.SetStyleSheet(css);
                worker.Parse(readerOnMetin);
                worker.EndDocument();
                worker.Close();

                Paragraph bas2 = new Paragraph();
                bas2.Alignment = Element.ALIGN_CENTER;
                bas2.SpacingAfter = AltBosluk;
                doc.Add(bas2);
            }
        }


        public static void BaslikEkle(string icerik, PdfPTable table, Font Tablefont, BaseColor BorderColor, BaseColor BackGroundColor, int _colspan, int rowspan = 1, int align = Element.ALIGN_LEFT)
        {
            PdfPCell cell;
            Phrase p = new Phrase(icerik, Tablefont);
            cell = new PdfPCell(p);
            cell.Colspan = _colspan;
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = align;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.MinimumHeight = 20f;
            cell.BorderColor = BorderColor;
            cell.BackgroundColor = BackGroundColor;


            table.AddCell(cell);
        }

        public static void ParagrafEkle(string icerik, iTextSharp.text.Document doc, Font font, int align = 0, float spacingAfter = 0, float spacingBefore = 0)
        {
            if (!string.IsNullOrEmpty(icerik))
            {
                Paragraph bas = new Paragraph(icerik, font);
                bas.Alignment = align;
                bas.SpacingAfter = spacingAfter;
                bas.SpacingBefore = spacingBefore;
                doc.Add(bas);
            }
        }
        public static void SatirEkle(iTextSharp.text.Document doc)
        {
            Phrase phrase = new Phrase(Environment.NewLine); // Boþ Bir Satýr
            doc.Add(phrase);
        }
    }
}
