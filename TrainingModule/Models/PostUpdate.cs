﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class PostUpdate
    {
        [Key]
        public int PostUpdateId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PostContent { get; set; } 
        [Required]
        public DateTime DateCreated { get; set; }

        [ForeignKey("IdentityUserId")]
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
