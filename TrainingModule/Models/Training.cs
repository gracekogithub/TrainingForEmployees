using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace TrainingModule.Models
{
    public class Training
    {
      
        public int TrainingId { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Upload Name")]
        public string Content { get; set; }
        [NotMapped]
        [DisplayName("File")]
        public IFormFile UploadFile { get; set; }

        public ICollection<ReviewerTraining> ReviewerTrainings { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public virtual List<Material> Materials { get; set; }
        public virtual TrainingDetail TrainingDetail { get; set; }
    }
}
