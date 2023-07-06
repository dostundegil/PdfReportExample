using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace PdfReportExample.Controllers
{
    public class ExcelReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerExcelReport()
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
            workSheet.Cell(1, 1).Value="Müşteri ID";
            workSheet.Cell(1, 2).Value="Müşteri Adı";
            workSheet.Cell(1, 3).Value="Müşteri Soyadı";
            workSheet.Cell(1, 4).Value="Müşteri Şehir";

            workSheet.Cell(2, 1).Value = "1";
            workSheet.Cell(2, 2).Value = "Ali Kaan";
            workSheet.Cell(2, 3).Value = "Yayla";
            workSheet.Cell(2, 4).Value = "İstanbul";

            workSheet.Cell(3, 1).Value = "2";
            workSheet.Cell(3, 2).Value = "Murat";
            workSheet.Cell(3, 3).Value = "Yücedağ";
            workSheet.Cell(3, 4).Value = "Ankara";

            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            var content=stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","customerlist.xlsx");
        }
    }
}
