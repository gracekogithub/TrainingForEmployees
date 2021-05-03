using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Comment
    {
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public Employee Employee { get; set; }
        public Manager Manager { get; set; }

    }
}
