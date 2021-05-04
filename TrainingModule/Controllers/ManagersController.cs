using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    public class ManagersController : Controller
    {
        private ApplicationDbContext _context;
        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ManagersController1
        public IActionResult Index()
        {
            var managers = _context.Managers.ToList();
            if (managers.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(managers);
        }

        // GET: ManagersController1/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagersController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagersController1/Create



        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager manager)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                manager.IdentityUserId = userId;
                _context.Managers.Add(manager);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
            //ViewBag.Products = new SelectList(product.Name, "Name", "Name");
        }
      
        // GET: ManagersController1/Edit/5
        public ActionResult Edit(int id)
        {
            var manager = _context.Managers.Where(e => e.ManagerId == id).FirstOrDefault();
            return View(manager);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Manager manager)
        {
            try
            {
                //var customerwithLatLng = _map.GetGeoCoding(customer);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                manager.IdentityUserId = userId;
                _context.Managers.Update(manager);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }

        }

        public IActionResult Delete(int? id)
        {
            var customer = _context.Managers.Where(e => e.ManagerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Manager customer)
        {
            try
            {
                _context.Managers.Remove(customer);
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
