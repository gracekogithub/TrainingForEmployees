using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class ReviewerTraining
    {
        [ForeignKey("Reviewer")]
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
