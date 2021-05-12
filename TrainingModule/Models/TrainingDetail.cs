﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class TrainingDetail
    {
        [Key]
        public int TrainingId { get; set; }
        public string content { get; set; }
        public virtual Training Training { get; set; }
    }
}
