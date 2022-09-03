using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;

namespace htmltopdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePDFController : ControllerBase
    {
        [HttpPost]  
        public IActionResult PDF()
        {

            HtmlToPdf htmlToPdf = new HtmlToPdf();

            string path = "#####"; // Path from which the file need to be read 
            string html = System.IO.File.ReadAllText(path);
            //    PdfDocument doc =  htmlToPdf.ConvertUrl(url);
            PdfDocument doc = htmlToPdf.ConvertHtmlString(html);
           
            doc.Save("Document.pdf");
            byte[] bytes = doc.Save();
            doc.Close();

            return Ok("Done");
        }

    }
}
