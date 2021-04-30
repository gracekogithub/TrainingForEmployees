using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string FeedbackContent { get; set; }
        

        
        public Manager manager { get; set; }
        public Employee employee { get; set; }
    }
}
