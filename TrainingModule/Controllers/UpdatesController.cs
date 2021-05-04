using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    public class UpdatesController : Controller
    {
        private ApplicationDbContext _context;
        public UpdatesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Update> update = _context.Updates.ToList();

            return View(update);
        }
        public IActionResult Create()
        {
            return View();
        }
      

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditNewsletter(Update update)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (update.UpdateId == 0)
        //        {
        //            _context.Updates.Add(update);
        //        }
        //        else
        //        {
        //            _context.Updates.Update(update);
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(update);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Update update)
        {
            try
            {
                _context.Updates.Add(update);
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
            var update = _context.Updates.Where(e => e.UpdateId == id).FirstOrDefault();
            return View(update);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Update update)
        {
            try
            {
                _context.Updates.Update(update);
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
            var data = _context.Updates.FirstOrDefault(o => o.UpdateId == id);
            _context.Updates.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
