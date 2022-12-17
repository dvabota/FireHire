using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using FireHire.Server.Data;

namespace FireHire.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly FireHireDbContext _context;

        public TestController(FireHireDbContext context)
        {
            _context = context;
        }


        [HttpGet("/test/getResumes")]
        public async Task<ActionResult> GetResumes()
        {
            return Ok(_context.Resumes.ToList());
        }

        [HttpGet("/test/execute0")]
        public async Task<string> Execute0()
        {
            return "ok123";
        }

        [HttpGet("/test/execute1")]
        public async Task<string> Execute1()
        {
            List<ResumeDb> resumes = _context.Resumes.ToList();

            foreach(var resume in resumes)
                _context.ScoringData.Add(new ScoringDataDb(0, 1, resume.Id, 0));

            _context.SaveChanges();

            return "ok";
        }

        [HttpGet("/test/execute2")]
        public async Task<string> Execute2()
        {
            string[] files = Directory.GetFiles("C:\\Users\\Asus\\Desktop\\data\\data\\INFORMATION-TECHNOLOGY\\");

            foreach(var f in files)
            {
                string data = "";
                PdfReader reader = new PdfReader(f);
                PdfDocument pdfDoc = new PdfDocument(reader);
                ITextExtractionStrategy textExtraction = new SimpleTextExtractionStrategy();

                for (int page = 1; page < pdfDoc.GetNumberOfPages(); page++)
                {

                    data += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), textExtraction);
                }

                try
                {
                    _context.Resumes.Add(new ResumeDb(0, data, "testName", "Not checked"));
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }


            return "ok";
        }



        [HttpPost("/test/execute3")]
        public async Task<ActionResult> GetImageString([FromForm] IEnumerable<IFormFile> files)
        {
            if (files.ToList().Count == 0)
                return BadRequest("File not found");

            foreach(var file in files)
            {
                string data = "";

                PdfReader reader = new PdfReader(file.OpenReadStream());
                PdfDocument pdfDoc = new PdfDocument(reader);
                ITextExtractionStrategy textExtraction = new SimpleTextExtractionStrategy();

                for (int page = 1; page < pdfDoc.GetNumberOfPages(); page++)
                {

                    data += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), textExtraction);
                }

                try
                {
                    _context.Resumes.Add(new ResumeDb(0, data, file.FileName, "Not checked"));
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return Ok();
        }
    }
}
