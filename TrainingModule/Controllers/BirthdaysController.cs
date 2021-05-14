using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    public class BirthdaysController : Controller
    {
        private ApplicationDbContext _context;
        public BirthdaysController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: BirthdaysController
        public ActionResult Index()
        {
            var birthday = _context.Birthdays;

            return View(birthday);
        }

        // GET: BirthdaysController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BirthdaysController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BirthdaysController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Birthday birthday)
        {
            try
            {
                _context.Birthdays.Add(birthday);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
             
                return View();
            }
        }

        // GET: BirthdaysController/Edit/5
        public ActionResult Edit(int id)
        {
            var birthday = _context.Birthdays.Where(e => e.BirthdayId == id).FirstOrDefault();
            return View(birthday);
        }

        // POST: BirthdaysController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Birthday birthday)
        {
            try
            {
                _context.Birthdays.Update(birthday);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
              
                return View();
            }
        }

        // GET: BirthdaysController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Birthdays.FirstOrDefault(o => o.BirthdayId == id);
            _context.Birthdays.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
