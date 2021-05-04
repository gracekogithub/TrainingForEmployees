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
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }

        //public Object TrainingMaterials { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<ManagerTraining> ManagerTraining { get; set; }
        public virtual ICollection<Material> Matrials { get; set; }
    }
}
