using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Material
    {
        [Key]
        public int MatrialId { get; set; }
        [Required]
        public string Title { get; set; }
        public string MaterialType { get; set; }
        public string Data { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }

    }
}
