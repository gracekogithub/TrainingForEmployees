using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;


namespace TrainingModule.Controllers
{
    public class MaterialsController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        public MaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View("Index", new Material());
        }


        [HttpPost]
        public IActionResult Save(Material material, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File not selected");
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                material.Photo = photo.FileName;
              
            }
            ViewBag.material = material;
            _context.SaveChanges();
            return View("Create");
        }
        
    }

}
