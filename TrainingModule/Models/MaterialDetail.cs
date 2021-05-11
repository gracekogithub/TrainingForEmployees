using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class MaterialDetail
    {
        [Key]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public string Content { get; set; }
        public virtual Material Material { get; set; }
    }
}
