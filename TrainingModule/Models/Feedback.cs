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
       
        public string Message { get; set; }
      
        public DateTime Created { get; set; }
        public int TrainingId { get; set; }

        public Training Training { get; set; }
      
    }
}
