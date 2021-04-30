using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Video { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
