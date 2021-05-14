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
        [Key]
        public int ManagerId { get; set; }
        [Display(Name = "First Name")]
        public string ManagerFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string ManagerLastName { get; set; }
        [Display(Name = "Extension Number")]
        public string Extension { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
