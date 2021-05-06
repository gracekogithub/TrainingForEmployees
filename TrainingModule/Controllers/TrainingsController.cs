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
    public class TrainingsController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;
        public TrainingsController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            

            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Training training)
        {
            try
            {
                _context.Trainings.Add(training);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var update = _context.Trainings.Where(e => e.TrainingId == id).FirstOrDefault();
            return View(update);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Training training)
        {
            try
            {
                _context.Trainings.Update(training);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }

        }
        
        
        
       
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(List<IFormFile> postedFiles)
        //{
        //    string wwwPath = _environment.WebRootPath;
        //    string contentPath = _environment.ContentRootPath;

        //    string path = Path.Combine(_environment.WebRootPath, "Uploads");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    List<string> uploadedFiles = new List<string>();
        //    foreach (IFormFile postedFile in postedFiles)
        //    {
        //        string fileName = Path.GetFileName(postedFile.FileName);
        //        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //        {
        //            postedFile.CopyTo(stream);
        //            uploadedFiles.Add(fileName);
        //            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
        //        }
        //    }
            
        //    return View();
        //}
        public IActionResult Upsert(int? id)
        {
            Training image = new Training();
            if (id == null)
            {
                
            }
            else
            {
                image = _context.Trainings.SingleOrDefault(i => i.TrainingId == id);
                if (image == null)
                {
                    return NotFound();
                }
            }
            
            return View(image);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(int id, Training image)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Count >0)
                {
                    byte[] item = null;
                    using (var itemfile = files[0].OpenReadStream())
                    {
                        using (var anotherItem = new MemoryStream())
                        {
                            itemfile.CopyTo(anotherItem);
                            item = anotherItem.ToArray();
                        }
                    }
                    image.File = item;
                }
                if (image.TrainingId == 0)
                {
                    _context.Trainings.Add(image);
                }
                else
                {
                    var moreimage = _context.Trainings.Where(i => i.TrainingId == id).FirstOrDefault();
                    moreimage.File = image.File;
                    if (files.Count > 0)
                    {
                        image.File = image.File;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Trainings.ToList() });
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Trainings.Where(e => e.TrainingId == id).FirstOrDefault();
            return View(customer);
        }
        //public IActionResult Delete(int id)
        //{
        //    var data = _context.Trainings.FirstOrDefault(o => o.TrainingId == id);
        //    _context.Trainings.Remove(data);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        //different way to delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _context.Trainings.Find(id);
            if (item == null)
            {
                return Json(new { success = false, message = "Error while deleteing." });
            }
            _context.Trainings.Remove(item);
            _context.SaveChanges();
            return Json(new { success = true, message = "Delete successful." });
        }
    }

}
