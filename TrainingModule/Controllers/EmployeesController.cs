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
    [Authorize(Roles = "Employee, Manager")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employees = _context.Employees.ToList();
            var theEmployee = employees.Where(cu => cu.IdentityUserId == currentUserId).SingleOrDefault();
            if (employees != null)
            {
                return RedirectToAction("Details", "Employee");
            }
            else
            {
                return View("Create", "Employee");
            }
        }


        public IActionResult Details(int id)
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = new Employee();
            if (this.User.IsInRole("Employee"))
            {
                employee = _context.Employees.Where(e => e.IdentityUserId == currentUserId).FirstOrDefault();
            }
            else
            {
                employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            }
            ViewBag.TrainingCategory = new SelectList(new List<string>() { "PowerPoint", "PDF" });
            if (employee.IdentityUserId == currentUserId || this.User.IsInRole("Employee"))
            {
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TrainingCategory = new SelectList(new List<string>() { "PowerPoint", "PDF" });
            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                ViewBag.TrainingCategory = new SelectList(new List<string>() { "PowerPoint", "PDF" });
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                //add more method here if necessary
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction($"Detail/{employee.EmployeeId}");
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }

        }


        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.EmployeeId == id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.TrainingCategory = new SelectList(new List<string>() { "PowerPoint", "PDF" });

            if (employee.IdentityUserId == userId || this.User.IsInRole("Manager"))
            {
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            try
            {
                var database = _context.Employees.Where(c => c.EmployeeId == employee.EmployeeId).FirstOrDefault();
                database.EmployeeFirstName = employee.EmployeeFirstName;
                database.EmployeeLastName = employee.EmployeeLastName;
                database.Comment = employee.Comment;

                //_context.Employees.Update(employees);

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
            var employee = _context.Employees.FirstOrDefault(o => o.EmployeeId == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Review(int id, Employee employee)
        {
            var review = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            _context.Update(review);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
