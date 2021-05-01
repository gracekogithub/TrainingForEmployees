using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string Department { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("manager")]
        public Manager Manager { get; set; }
    }
}
