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
        public string UserName { get; set; }
        [Required]
        public string FeedbackContent { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Created { get; set; }
         
  
        [ForeignKey("IdentityUserId")]
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        [ForeignKey("Reply")]
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }
       
    }
}
