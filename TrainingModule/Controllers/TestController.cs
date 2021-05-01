using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    //[Authorize(Roles = "Manager")]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostUpdates
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostUpdates.ToListAsync());
        }

        // GET: PostUpdates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postUpdate = await _context.PostUpdates
                .FirstOrDefaultAsync(m => m.PostUpdateId == id);
            if (postUpdate == null)
            {
                return NotFound();
            }

            return View(postUpdate);
        }

        // GET: PostUpdates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostUpdates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostUpdate postUpdate)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                postUpdate.IdentityUserId = userId;
                _context.PostUpdates.Add(postUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postUpdate);
        }

        // GET: PostUpdates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postUpdate = await _context.PostUpdates.FindAsync(id);
            if (postUpdate == null)
            {
                return NotFound();
            }
            return View(postUpdate);
        }

        // POST: PostUpdates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostUpdate postUpdate)
        {
            if (id != postUpdate.PostUpdateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostUpdateExists(postUpdate.PostUpdateId))
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
            return View(postUpdate);
        }

        // GET: PostUpdates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postUpdate = await _context.PostUpdates
                .FirstOrDefaultAsync(m => m.PostUpdateId == id);
            if (postUpdate == null)
            {
                return NotFound();
            }

            return View(postUpdate);
        }

        // POST: PostUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postUpdate = await _context.PostUpdates.FindAsync(id);
            _context.PostUpdates.Remove(postUpdate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostUpdateExists(int id)
        {
            return _context.PostUpdates.Any(e => e.PostUpdateId == id);
        }
    }
}
