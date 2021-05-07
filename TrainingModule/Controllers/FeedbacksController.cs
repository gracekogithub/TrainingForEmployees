using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;
using TrainingModule.ViewModels;

namespace TrainingModule.Controllers
{
    //[Authorize(Roles = "Employee")]
    public class FeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var post = _context.Feedbacks.Include(a => a.Training);
            return View(await post.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(a => a.Training)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }


        public IActionResult Create()
        {
            ViewData["FeedbackId"] = new SelectList(_context.Trainings, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Trainings, "Id", "Id", feedback.FeedbackId);
            return View(feedback);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Trainings, "Id", "Id", feedback.FeedbackId);
            return View(feedback);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.FeedbackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Trainings, "Id", "Id", feedback.FeedbackId);
            return View(feedback);
        }
        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(f => f.FeedbackId == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.Feedbacks
                .Include(a => a.Training)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (articleComment == null)
            {
                return NotFound();
            }

            return View(articleComment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(TrainingFeedbackVM post)
        {
            
            var message = post.Message;
            var postId = post.FeedbackId;
          

            Feedback feedback = new Feedback()
            {
                FeedbackId = postId,
                Message = message,
                Created = DateTime.Now
            };
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();

            return RedirectToAction("Details", "Articles", new{ id = postId});
        }
    }
}
