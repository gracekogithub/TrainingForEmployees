
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

using TrainingModule.Data;

using TrainingModule.Models;

using TrainingModule.ViewModel;


namespace TrainingModule.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult YoutubeIndex()
        {
            WebRequest request = WebRequest.Create("https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=50&q=hematology&key=" + YoutubeApiKeys.apiKey);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            Youtube search = parsedString.ToObject<Youtube>();
            return View(search);

        }
        //[HttpPost]
        //public async Task<IActionResult> Comment(CommentViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //        return RedirectToAction("Post", new { id = vm.PostId });

        //    var post = _repo.GetPost(vm.PostId);
        //    if (vm.MainCommentId == 0)
        //    {
        //        post.MainComments = post.MainComments ?? new List<MainComment>();

        //        post.MainComments.Add(new MainComment
        //        {
        //            Message = vm.Message,
        //            Created = DateTime.Now,
        //        });

        //        _repo.UpdatePost(post);
        //    }
        //    else
        //    {
        //        var comment = new SubComment
        //        {
        //            MainCommentId = vm.MainCommentId,
        //            Message = vm.Message,
        //            Created = DateTime.Now,
        //        };
        //        _repo.AddSubComment(comment);
        //    }

        //    await _repo.SaveChangesAsync();

        //    return RedirectToAction("Post", new { id = vm.PostId });
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}


    }
}
