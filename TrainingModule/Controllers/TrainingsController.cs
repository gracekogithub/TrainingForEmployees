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
using TrainingModule.ViewModels;
using ExcelDataReader;

using Grpc.Core;

namespace TrainingModule.Controllers
{
    public class TrainingsController : Controller
    {
        //private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;
        public TrainingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            List <Training> training = _context.Trainings.ToList();
            
            return View(training);
        }
        [HttpPost]
        public IActionResult IndexFile(IFormFile file, [FromServices] IHostingEnvironment environment)
        {
            string fileName = $"{environment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var trainings = this.GetTrainingList(file.FileName);
            return View(trainings);
        }
        private List<Training> GetTrainingList(string fName)
        {
            List<Training> trainings = new List<Training>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        trainings.Add(new Training()
                        {
                            Title = reader.GetValue(0).ToString(),
                            Body = reader.GetValue(1).ToString(),
                        });
                    }
                }
                return trainings;
            }
        }
        [HttpGet]
        public IActionResult SaveImages()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveImages(/*UploadImagesVM uplodvm, */IFormFile uploadedImage)
        {
            if (uploadedImage.Length>0)
            {
                string ImageFileName = Path.GetFileName(uploadedImage.FileName);

                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", ImageFileName);
                var stream = new FileStream(FolderPath, FileMode.Create);
                uploadedImage.CopyToAsync(stream);
            }
           
                //material.File = photo.FileName;

            
            ViewBag.Message = "File loaded Sucessfully";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Training tr = _context.Trainings.Find(id);
            TrainingFeedbackVM feed = new TrainingFeedbackVM();

            if (tr == null)
            {
                return NotFound();
            }
            //feed.FeedbackId = id.Value;
            //feed.Author = tr.Author;
            //var comments = _context.Comments.Where(d => d.TrainingId.Equals(id.Value)).ToList();
            //feed.Feedbacks = comments;

            return View(feed);
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult UploadFile(Training training)
        //{
        //    try
        //    {
        //        _context.Trainings.Add(training);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return View();
        //    }
        //}
       

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

        public IActionResult Delete(int id)
        {
            var data = _context.Trainings.FirstOrDefault(o => o.TrainingId == id);
            _context.Trainings.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


      
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
        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var item = _context.Trainings.Find(id);
        //    if (item == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleteing." });
        //    }
        //    _context.Trainings.Remove(item);
        //    _context.SaveChanges();
        //    return Json(new { success = true, message = "Delete successful." });
        //}
    }

}
