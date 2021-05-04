using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Update
    {
        [Key]
        public int UpdateId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PostContent { get; set; } 
        [Required]   
        public DateTime DateCreated { get; set; }


        public virtual IdentityUser IdentityUser { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
