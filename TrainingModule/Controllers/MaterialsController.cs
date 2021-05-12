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
    public class MaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: MaterialsController
        public IActionResult Index()
        {
            List<Material> material = _context.Materials.ToList();
            return View(material);
        }

        public IActionResult AddOrUpdate(int? id)
        {
            Material mat = new Material();
            if (id == null)
            {
                return View(mat);
            }
            //this for edit
            mat = _context.Materials.FirstOrDefault(u => u.MaterialId == id);
            if (mat == null)
            {
                return NotFound();
            }
            return View(mat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Material mat)
        {
            if (ModelState.IsValid)
            {
                if (mat.MaterialId == 0)
                {
                    //this is create
                    _context.Materials.Add(mat);
                }
                else
                {
                    //this is an update
                    _context.Materials.Update(mat);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mat);

        }

        // GET: MaterialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaterialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Material material)
        {
            try
            {
                _context.Materials.Add(material);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: MaterialsController/Edit/5
        public IActionResult Edit(int id)
        {
            var update = _context.Materials.Where(e => e.MaterialId == id).FirstOrDefault();
            return View(update);
        }

        // POST: MaterialsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Material material)
        {
            try
            {
                _context.Materials.Update(material);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }

        // GET: MaterialsController/Delete/5
     
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Materials.FirstOrDefault(u => u.MaterialId == id);
            _context.Materials.Remove(objFromDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
