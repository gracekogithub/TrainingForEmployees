using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    public class FileHelperController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment = null;

        public FileHelperController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            FileHelper fileObj = new FileHelper();
            fileObj.Name = fileName;
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
            int nId = 1;
            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.Files.Add(new FileHelper()
                {
                    FileId = nId++,
                    Name = Path.GetFileName(pdfPath),
                    Path = pdfPath
                });
            }
            return View(fileObj);
        }


        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment )
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{ file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return Index();
        }
        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
    }
}