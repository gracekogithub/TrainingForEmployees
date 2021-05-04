using Microsoft.AspNetCore.Http;
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
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public Training Training { get; set; }
        public Manager Manager { get; set; }
    }
}
