using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class ManagerTraining
    {
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public virtual Training Training { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
