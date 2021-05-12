using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Data;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    public class JointTableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JointTableController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TrainController> traininglist = _context.Trainings.ToList();
            List<Reviewer> reviewerlist = _context.Reviewers.ToList();
            //ViewData["jointables"]=from t in traininglist join r in reviewerlist on t.Content equals
            return View();
        }
    }
}
