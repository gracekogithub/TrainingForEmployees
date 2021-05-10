using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    //[Authorize(Roles = "Employee")]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(a => a.IdentityUserId==userId).FirstOrDefault();
            if (employee == null)
            {
                return View("Create");
            }
            var posts = _context.Posts.Where(p => p.Training.TrainingId == employee.EmployeeId).ToList();
            return View(posts);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Employees
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
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
        public async Task<IActionResult> Create(Comment feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Trainings, "Id", "Id", feedback.Id);
            return View(feedback);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUser);
            return View(employee);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(employee.EmployeeId))
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
            ViewData["IndentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }
        private bool FeedbackExists(int id)
        {
            return _context.Comments.Any(f => f.Id == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(TrainingFeedbackVM post)
        {
            
            var message = post.Message;
            var author = post.Author;
            var postId = post.FeedbackId;
          

            Comment feedback = new Comment()
            {
                Id = postId,
                Author= author,
                Message = message,
                Created = DateTime.Now
            };
            _context.Comments.Add(feedback);
            _context.SaveChanges();

            return RedirectToAction("Details", "Messages", new{ id = postId});
        }
    }
}
