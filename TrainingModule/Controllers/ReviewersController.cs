using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingModule.Data;
using TrainingModule.Models;
using TrainingModule.ViewModel;

namespace TrainingModule.Controllers
{
    public class ReviewersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewersController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            List<Reviewer>review = _context.Reviewers.Include(u => u.Trainings).ToList();
            return View(review);
        }

        public IActionResult AddOrUpdate(int? id)
        {
            ReviewVM obj = new ReviewVM();
            obj.TrainingList = _context.Trainings.Select(i => new SelectListItem
            {
                Text = i.Title,
                Value = i.TrainingId.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Reviewer = _context.Reviewers.FirstOrDefault(u => u.ReviewerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ReviewVM obj)
        {
            if (obj.Reviewer.ReviewerId == 0)
            {
                //this is create
                _context.Reviewers.Add(obj.Reviewer);
            }
            else
            {
                //this is an update
                _context.Reviewers.Update(obj.Reviewer);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Reviewers/Details/5
        public IActionResult Details(int? id)
        {
            ReviewVM review = new ReviewVM();
            if (id == null)
            {
                return View(review);
            }

            var reviewer = _context.Reviewers
                .FirstOrDefaultAsync(m => m.ReviewerId == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviewers.FirstOrDefault(u => u.ReviewerId == id);
            _context.Reviewers.Remove(review);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        private bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(e => e.ReviewerId == id);
        }
    }
}
