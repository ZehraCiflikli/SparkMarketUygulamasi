using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.Business.Common
{

    public static class RaporGenerator
    {

        public static byte[] DenetimPlaniRaporAl(UrunAddViewModel model)
        {
            string BASLIK2 = "sinanarslan";
            string rapor_tarihi = DateTime.Now.ToString();


            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 30f, 30f, 20f, 10f);
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
            ParagrafEkle("ANA RAPOR BAŞLIĞI ", doc, AltBaslik, Element.ALIGN_CENTER, 5f);
            ParagrafEkle("ALT RAPOR BAŞLIĞI", doc, AltBaslik, Element.ALIGN_CENTER, 30f, 5f);



            HtmlMetinEkle("<b>HTML İÇEREN BİR METİN</b>", doc, 15f);

            #region üst tablo
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            // Set the relative widths of the columns
            float[] columnWidths = { 20f }; // First column will be half the width of the second column
            table.SetWidths(columnWidths);

            BaslikEkle("FAALİYET LİSTESİ", table, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);

            // Add the table to the document
            doc.Add(table);
            #endregion

            #region 
            PdfPTable tableHeader = new PdfPTable(6);
            tableHeader.WidthPercentage = 100;
            // Set the relative widths of the columns
            float[] columnWidthsHeader = { 8f, 10f, 20f, 36f, 8f, 8f }; // First column will be half the width of the second column
            tableHeader.SetWidths(columnWidthsHeader);

            BaslikEkle("KOD", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            BaslikEkle("DÖNEM", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            BaslikEkle("İDARİ DÜZEY", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            BaslikEkle("FAALİYET", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            BaslikEkle("RİSK DÜZEYİ", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            BaslikEkle("ÖLÇEK", tableHeader, Tablefont, new BaseColor(13, 198, 254), new BaseColor(212, 225, 250), 1, 1, Element.ALIGN_CENTER);
            // Add the table to the document
            doc.Add(tableHeader);
            #endregion

            #region alt tablo
            PdfPTable tablealt = new PdfPTable(6);
            tablealt.WidthPercentage = 100;

            float[] altcolumnWidths = { 8f, 10f, 20f, 36f, 8f, 8f }; // First column will be half the width of the second column
            tablealt.SetWidths(altcolumnWidths);

            foreach (var item in model.KategoriListe)
            {
                //HucreEkle(item.KOD, tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);
                //HucreEkle(item.DONEMID + "", tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);
                //HucreEkle("\n" + item.BIRIMADI + "\n\n" + item.IDARIDUZEYADI + "\n\n", tablealt, Tablefont, 1, 1, Element.ALIGN_LEFT);
                //HucreEkle("\n" + item.EVRENPROGRAMADI + "\n\n" + item.EVRENALTPROGRAMADI + "\n\n" + item.EVRENFAALIYETADI + "\n\n", tablealt, Tablefont, 1, 1, Element.ALIGN_LEFT);
                //HucreEkle(item.RISKDUZEYIIFADE, tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);
                //HucreEkle(item.DENETIMALANIOLCEKMETNI, tablealt, Tablefont, 1, 1, Element.ALIGN_CENTER);

            }

            doc.Add(tablealt);
            #endregion
            HtmlMetinEkle("HTML İÇERİK EKLE", doc, 20f, 20f);
            doc.Close();


            return output.ToArray();
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
        public static void HtmlMetinEkle(string icerik, Document doc, float AltBosluk = 0, float UstBosluk = 0)
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

        public static void ParagrafEkle(string icerik, Document doc, Font font, int align = 0, float spacingAfter = 0, float spacingBefore = 0)
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
        public static void SatirEkle(Document doc)
        {
            Phrase phrase = new Phrase(Environment.NewLine); // Boş Bir Satır
            doc.Add(phrase);
        }





    }

}
