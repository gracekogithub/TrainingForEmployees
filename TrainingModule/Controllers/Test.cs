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
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public IActionResult Index()
        {
            List<Training> trainings = _context.Trainings.Include(u => u.Materials).Include(u => u.ReviewerTrainings)
                .ThenInclude(u => u.Reviewer).ToList();
            return View(trainings);
        }

        public IActionResult AddOrUpdate(int? id)
        {
            TrainingVM training = new TrainingVM();
            ViewBag.TrainingFormat = new SelectList(new List<string>() { "Pdf", "Image" });
            //training.MaterialList = _context.Materials.Select(i => new SelectListItem
            //{
            //    Value = i.MaterialId.ToString(),
            //    Text = i.TrainingFormat,
            //});
            if (id == null)
            {
                return View(training);
            }
            //this for edit
            training.Training = _context.Trainings.FirstOrDefault(u => u.TrainingId == id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(TrainingVM obj)
        {
            if (obj.Training.TrainingId == 0)
            {
                //this is create
                _context.Trainings.Add(obj.Training);
            }
            else
            {
                //this is an update
                _context.Trainings.Update(obj.Training);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // GET: Trainings/Details/5
        public IActionResult Details(int? id)
        {
            TrainingVM train = new TrainingVM();
            if (id == null)
            {
                return View(train);
            }

            train.Training =_context.Trainings.Include(u=>u.TrainingDetail)
                .FirstOrDefault(m => m.TrainingId == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(TrainingVM training)
        {
            if (training == null)
            {
                //this is create
                _context.Add(training);
                _context.SaveChanges();

                var FromDb = _context.Trainings.FirstOrDefault(u => u.TrainingId == training.Training.TrainingId);
            
                _context.SaveChanges();
            }
            else
            {
                //this is an update
                _context.Update(training.Training);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingId,Title,Content")] Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingId,Title,Content")] Training training)
        {
            if (id != training.TrainingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.TrainingId))
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
            return View(training);
        }

        // GET: Trainings/Delete/5
        public IActionResult Delete(TrainingVM train)
        {
            if (train == null)
            {
                return NotFound();
            }

            var training = _context.Trainings
                .FirstOrDefault();
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training = await _context.Trainings.FindAsync(id);
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.TrainingId == id);
        }


        public IActionResult TrainingAction(int id)
        {
            TrainingReviewVM obj = new TrainingReviewVM
            {
                ReviewerTrainingList = _context.ReviewerTrainings.Include(u => u.Reviewer).Include(u => u.Training)
                                    .Where(u => u.TrainingId == id).ToList(),
                ReviewerTraining = new ReviewerTraining()
                {
                    TrainingId = id
                },
                Training = _context.Trainings.FirstOrDefault(u => u.TrainingId == id)
            };
            List<int> guide = obj.ReviewerTrainingList.Select(u => u.ReviewerId).ToList();
          
            var tempList = _context.Reviewers.Where(u => !guide.Contains(u.ReviewerId)).ToList();

            obj.ReviewList = tempList.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.ReviewerId.ToString()
            });

            return View(obj);

        }

        [HttpPost]
        public IActionResult TrainingAction(TrainingReviewVM trainingReviewVM)
        {
            if (trainingReviewVM.ReviewerTraining.TrainingId != 0 && trainingReviewVM.ReviewerTraining.ReviewerId != 0)
            {
                _context.ReviewerTrainings.Add(trainingReviewVM.ReviewerTraining);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(TrainingAction), new { @id = trainingReviewVM.ReviewerTraining.TrainingId });
        }

        [HttpPost]
        public IActionResult Remove(int authorId, TrainingReviewVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Training.TrainingId;
            ReviewerTraining bookAuthor = _context.ReviewerTrainings.FirstOrDefault(
                u => u.TrainingId == authorId && u.TrainingId == bookId);

            _context.ReviewerTrainings.Remove(bookAuthor);
            _context.SaveChanges();
            return RedirectToAction(nameof(TrainingAction), new { @id = bookId });
        }

    }
}
