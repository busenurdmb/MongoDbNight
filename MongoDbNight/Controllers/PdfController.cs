using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using MongoDbNight.Services.CustomerServices;

namespace MongoDbNight.Controllers
{
    public class PdfController : Controller
    {
        private readonly ICustomerService _customerService;

        public PdfController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ExportCustomersToPdf()
        {
            // Müşteri verilerini al
            var customers = await _customerService.GetAllCustomerAsync();

            // Bellekte bir akış oluştur
            using (var stream = new MemoryStream())
            {
                // iTextSharp kullanarak PDF dosyasını oluştur
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        using (var document = new Document(pdf))
                        {
                            // Başlık ekle
                            document.Add(new Paragraph("Customer List").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20));

                            // Tablo oluştur
                            var table = new Table(new float[] { 2, 2, 2, 2 }).UseAllAvailableWidth();

                            // Tablo başlıklarını ekle
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Name")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("City")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Phone")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Email")));

                            // Müşteri bilgilerini tabloya ekle
                            foreach (var customer in customers)
                            {
                                table.AddCell(new Cell().Add(new Paragraph(customer.CustomerNameSurname)));
                                table.AddCell(new Cell().Add(new Paragraph(customer.CustomerCity)));
                                table.AddCell(new Cell().Add(new Paragraph(customer.CustomerPhone)));
                                table.AddCell(new Cell().Add(new Paragraph(customer.CustomerMail)));
                            }

                            // Tabloyu dökümana ekle
                            document.Add(table);
                        }
                    }
                }

                // MemoryStream'in içeriğini byte dizisine dönüştür
                var content = stream.ToArray();

                // Dosya türü ve dosya adı
                var contentType = "application/pdf";
                var fileName = "customers.pdf";

                // Dosyayı indirilebilir olarak döndür
                return File(content, contentType, fileName);
            }
        }

     }
}

