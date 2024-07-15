using Microsoft.AspNetCore.Mvc;
using MongoDbNight.Services.OrderServices;
using OfficeOpenXml;

namespace MongoDbNight.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IOrderService _orderService;

        public ExcelController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ExportOrdersToExcel()
        {
            // Sipariş verilerini al
            var orders = await _orderService.ResultOrderWithCustomerWithProductDto();

            // Excel paketini kullanarak yeni bir Excel dosyası oluştur
            using (var package = new ExcelPackage())
            {
                // Yeni bir sayfa ekle ve adını "Orders" olarak ayarla
                var worksheet = package.Workbook.Worksheets.Add("Orders");

                // Başlıkları yazma
                var headers = new[] { "Müşteri", "Ürün İsmi",  "Adet", "Tarih" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                // Verileri yazma
                for (int i = 0; i < orders.Count; i++)
                {
                    var order = orders[i];
                    worksheet.Cells[i + 2, 1].Value = order.Customer.CustomerNameSurname;
                    worksheet.Cells[i + 2, 2].Value = order.Product.ProductName;
                    worksheet.Cells[i + 2, 3].Value = order.OrderProductPiece;
                    worksheet.Cells[i + 2, 4].Value = order.OrderDate.ToString("yyyy-MM-dd");
                  
                 
                }

                // Bellekte bir akış oluştur ve Excel paketini bu akışa kaydet
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0; // Akışın başına dön

                // İçerik tipi ve dosya adını ayarla
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "orders.xlsx";

                // Dosyayı indirilebilir olarak döndür
                return File(stream, contentType, fileName);
            }
        }
    }
}
