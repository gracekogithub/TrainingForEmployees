﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Post
    {

        [ForeignKey("Update")]
        public int UpdateId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public Update Update { get; set; }
        public Manager Manager { get; set; }

    }
}
