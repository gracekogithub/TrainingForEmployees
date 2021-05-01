using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        
        public string FeedbackContent { get; set; }
        public string FeedbackTitle { get; set; }


        [ForeignKey("Manager")]

        public Manager Manager { get; set; }
        [ForeignKey("Employee")]
        public Employee Employee { get; set; }
    }
}
