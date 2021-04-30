using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Manager")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
