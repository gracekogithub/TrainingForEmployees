using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: Reviewers
        public IActionResult Index()
        {
            List<Reviewer> trainings = _context.Reviewers.Include(u => u.ReviewerTrainings)
                .ThenInclude(u => u.Training).ToList();
            return View(trainings);
        }

        // GET: Reviewers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers.Include(u => u.ReviewerTrainings)
                .ThenInclude(u => u.Training)
                .FirstOrDefaultAsync(m => m.ReviewerId == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // GET: Reviewers/Create
        public IActionResult Create(int id)
        {
            TrainingReviewVM obj = new TrainingReviewVM
            {
                ReviewerTrainingList = _context.ReviewerTrainings.Include(u => u.Training).Include(u => u.Reviewer)
                                    .Where(u => u.ReviewerId == id).ToList(),
                ReviewerTraining = new ReviewerTraining()
                {
                    ReviewerId = id
                },
                Reviewer = _context.Reviewers.FirstOrDefault(u => u.ReviewerId == id)
            };
            List<int> guide = obj.ReviewerTrainingList.Select(u => u.TrainingId).ToList();
            var tempList = _context.Reviewers.Where(u => !guide.Contains(u.ReviewerId)).ToList();
            obj.ReviewList = tempList.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.ReviewerId.ToString()
            });

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewerId,Name,Message,Created")] TrainingReviewVM trainingReviewVM)
        {
            if (ModelState.IsValid)
            {

                _context.ReviewerTrainings.Add(trainingReviewVM.ReviewerTraining);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create), new { @id = trainingReviewVM.ReviewerTraining.ReviewerId });
        }

        // GET: Reviewers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return NotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewerId,Name,Message,Created")] Reviewer reviewer)
        {
            if (id != reviewer.ReviewerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Reviewers.Update(reviewer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewerExists(reviewer.ReviewerId))
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
            return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers
                .FirstOrDefaultAsync(m => m.ReviewerId == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // POST: Reviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewer = await _context.Reviewers.FindAsync(id);
            _context.Reviewers.Remove(reviewer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(e => e.ReviewerId == id);
        }
    }
}
