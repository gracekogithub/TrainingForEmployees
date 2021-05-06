using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        
      
    }
}
