using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class ManagerFeedback
    {
        [ForeignKey("Feedback")]
        public int FeedbackId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
       
        public virtual Feedback Feedback { get; set; }
        public virtual Manager Manager { get; set; }

    }
}
