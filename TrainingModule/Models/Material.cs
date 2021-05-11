using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
 
        public string PdfName { get; set; }
        
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("PDF File")]
        public IFormFile PdfFile { get; set; }
        [NotMapped]
        [DisplayName("Image File")]
        public IFormFile ImageFile { get; set; }
        public virtual List<Training> Trainings { get; set; }
        
    }
}
