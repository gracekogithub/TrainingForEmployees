using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public virtual Training Trainings { get; set; }
        public virtual Employee Employee { get; set; }
        
    }
}
