using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class EmployeeFeedback
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Feedback")]
        public int FeedbackId { get; set; }
       
        public virtual Employee Employee { get; set; }
        public virtual Feedback Feedback { get; set; }

    }
}
