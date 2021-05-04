using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Feedback
    {

        [Key]
        public int FeedbackId { get; set; }
        [Required]
        public string FeedbackContent { get; set; }
        public virtual ICollection<EmployeeFeedback> EmployeeFeedbacks { get; set; }
        public virtual ICollection<ManagerFeedback> ManagerFeedbacks { get; set; }
    }
}
