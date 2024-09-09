using LauriesEC.Fences.Services.Fences;
using LauriesEC.Service.Calculator;
using LauriesEC.Service.Calculator.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;


namespace LauriesEC.Fence.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IWebHostEnvironment _host;
        public IInvoice _invoice;
        

        public InvoiceController(IWebHostEnvironment host, IInvoice iinvoice)
        {
            _invoice = iinvoice;
            _host = host;
            QuestPDF.Settings.License = LicenseType.Community;
        }
        [HttpPost("download")]
        public IActionResult DownloadPdf(FenceModelFromTheBody viewFence)
        {
            var imagePath = Path.Combine(_host.WebRootPath, "images/LogoWallpapers2.jpg");
            byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
            var pdfData = _invoice.DownloadPdf(imageData, viewFence);
            
            return File(pdfData, "application/pdf", "quote.pdf"); // Use the File method to return the PDF
        }
    }
}
