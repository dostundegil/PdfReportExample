using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace PdfReportExample.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            Guid guid = Guid.NewGuid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/file1.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Rapor hazırlandı.");
            document.Add(paragraph);  
            document.Close();
            return File("/pdfreports/"+ "file1.pdf", "applicaton/pdf", "file1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/file2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Müşteri Adı");
            pdfTable.AddCell("Müşteri Soyadı");
            pdfTable.AddCell("Müşteri Şehri");

            pdfTable.AddCell("Ali");
            pdfTable.AddCell("Çınar");
            pdfTable.AddCell("İstanbul");


            pdfTable.AddCell("Hakan");
            pdfTable.AddCell("Uçar");
            pdfTable.AddCell("Bursa");

            document.Add(pdfTable);
            document.Close();
            return File("/pdfreports/" + "file2.pdf", "applicaton/pdf", "file2.pdf");
        }
    }
}
