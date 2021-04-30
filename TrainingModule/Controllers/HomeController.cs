using Microsoft.AspNetCore.Http;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult YoutubeIndex()
        {
            WebRequest request = WebRequest.Create("https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=50&q=hematology&key=" + YoutubeApiKeys.apiKey);
            //request.Headers.Add("Authorization Basic: ") + secretKey);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            Youtube search = parsedString.ToObject<Youtube>();
            return View(search);

        }
        public IActionResult Upload(IFormFile file)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
