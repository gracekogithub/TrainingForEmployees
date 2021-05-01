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
    public class PostUpdateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostUpdateController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: PostUpdateController
        public ActionResult Index()
        {
            IEnumerable<PostUpdate> updates = _context.PostUpdates;
            return View(updates);
        }

        // GET: PostUpdateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostUpdateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostUpdateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostUpdate daily)
        {
            try
            {
                _context.PostUpdates.Add(daily);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostUpdateController/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = _context.PostUpdates.Find(id);
            return View(edit);
        }

        // POST: PostUpdateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostUpdate edit)
        {
            try
            {
                _context.PostUpdates.Update(edit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostUpdateController/Delete/5
        public ActionResult Delete(int? id)
        {
            var postUpdate = _context.PostUpdates.Find(id);
            return View(postUpdate);
        }

        // POST: PostUpdateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, PostUpdate editting)
        {
            try
            {
                _context.PostUpdates.Remove(editting);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
