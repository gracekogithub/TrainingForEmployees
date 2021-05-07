using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employees = _context.Employees.Where(cu => cu.IdentityUserId == userId).ToList();
            if (employees.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(employees);
            }
        }

   
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

   



 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employees)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employees.IdentityUserId = userId;
                _context.Employees.Add(employees);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                Console.WriteLine("Error");
                return View();
            }
    
        }
      

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employees)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employees.IdentityUserId = userId;
                _context.Employees.Update(employees);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }

        }
        //public IActionResult Delete(int id)
        //{
        //    var data = _context.Employees.FirstOrDefault(o => o.EmployeeId == id);
        //    _context.Employees.Remove(data);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Review(int id, Employee employee)
        {
            try
            {
 
                var review = _context.Employees.FindAsync(id);
                _context.Employees.Update(employee);
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
