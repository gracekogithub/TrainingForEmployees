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


        public IActionResult Index(int? value, Employee employees)
        {
            //ViewBag.TrainingCategory = new SelectList(new List<string>() { "PowerPoint", "PDF" });

            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var managerSignIn = _context.Managers.Where(cu => cu.IdentityUserId == currentUserId).SingleOrDefault();
            if (managerSignIn == null)
            {
                return View("Create");
            }
            var list = _context.Employees.ToList();
            return View();
        }
        public IActionResult Details(int id)
        {

            var customer = _context.Employees.SingleOrDefault(c => c.EmployeeId == id);
            return View(customer);
        }


        public IActionResult Create()
        {
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                manager.IdentityUserId = userId;
                _context.Managers.Add(manager);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
            //ViewBag.Products = new SelectList(product.Name, "Name", "Name");
        }
      

    
      

        public IActionResult Edit(int? id)
        {
            var employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
