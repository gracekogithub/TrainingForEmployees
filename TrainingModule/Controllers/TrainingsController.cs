using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;
using TrainingModule.ViewModels;

namespace TrainingModule.Controllers
{
    public class TrainingsController : Controller
    {
        private ApplicationDbContext _context;
        public TrainingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Training> training = _context.Trainings.ToList();

            return View(training);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Trainings.Where(e => e.TrainingId == id).FirstOrDefault();
            return View(customer);
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
        public IActionResult Delete(int id)
        {
            var data = _context.Trainings.FirstOrDefault(o => o.TrainingId == id);
            _context.Trainings.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult SelectMaterials(int? id)
        //{
        //    TrainingVM training = new TrainingVM();
        //    training.MaterialList = _context.
        //    if (id == null)
        //    {
        //        return View(update);
        //    }
        //    update = _context.Updates.FirstOrDefault(u => u.UpdateId == id);
        //    if (update == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(update);
        //}
    }
}
