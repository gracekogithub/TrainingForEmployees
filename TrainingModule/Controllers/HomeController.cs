using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TrainingModule.ActionFilters;
using TrainingModule.Models;

namespace TrainingModule.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
