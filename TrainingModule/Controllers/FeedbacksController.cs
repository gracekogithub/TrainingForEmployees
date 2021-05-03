using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;
using TrainingModule.ViewModels;
using Microsoft.AspNetCore.Session;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TrainingModule.Controllers
{
    //[Authorize(Roles="Employee, Manager")]
    public class FeedbacksController : Controller
    {
        private ApplicationDbContext _context;

        public FeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: FeedbacksController
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeefeedback = _context.Feedbacks.Include(f => f.Reply).Where(cu => cu.IdentityUserId == userId).ToList();
            if (employeefeedback.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(employeefeedback);
            }
        }

      
       

        // GET: FeedbacksController/Create
        public ActionResult Create()
        {
            return View();
        }

       
       
        public ActionResult Delete(int? id)
        {
            var feedback = _context.Feedbacks.Where(e => e.FeedbackId == id).FirstOrDefault();
            return View(feedback);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Feedback feedback)
        {
            try
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Feedback feedback)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                feedback.IdentityUserId = userId;
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            //ViewData["apiKeys"] = GoogleApiKeys.apiKey;
            var feedback = _context.Feedbacks.Where(e => e.FeedbackId == id).FirstOrDefault();
            return View(feedback);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Feedback feedback)
        {
            try
            {
                //var customerwithLatLng = _map.GetGeoCoding(customer);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                feedback.IdentityUserId = userId;
                _context.Feedbacks.Update(feedback);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }

        }
    }
}
