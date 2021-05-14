using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagersController : Controller
    {
        private ApplicationDbContext _context;
        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var manager = _context.Managers.Where(c => c.IdentityUserId == userId).ToList();
            if (manager.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(manager);
            }
        }
        public IActionResult Details(int id)
        {

            var customer = _context.Employees.SingleOrDefault(c => c.EmployeeId == id);
            return View(customer);
        }


        public IActionResult Create()
        {
            return View();
        }



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
        public IActionResult Delete(int id)
        {
            var data = _context.Managers.FirstOrDefault(o => o.ManagerId == id);
            _context.Managers.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
