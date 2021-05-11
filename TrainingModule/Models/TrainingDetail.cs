using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class TrainingDetail
    {
        [Key]
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public string Content { get; set; }
        public virtual Training Training { get; set; }
    }
}
