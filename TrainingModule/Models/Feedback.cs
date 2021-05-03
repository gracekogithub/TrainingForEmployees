using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        
        public string FeedbackContent { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Created { get; set; }
        public ICollection<Reply>Reply { get; set; }

        [ForeignKey("IdentityUserId")]
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
