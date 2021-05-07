using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Models;

namespace TrainingModule.ViewModels
{
    public class TrainingFeedbackVM
    {
        public int FeedbackId { get; set; }
     
        public string Title { get; set; }
   
        public string Message { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}
