using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        public string Comment { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

       
    }
}
