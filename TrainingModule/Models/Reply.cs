using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string ReplyContent { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Created { get; set; }
        [ForeignKey("FeedbackId")]
        public int FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }
        [ForeignKey("IdentityUserId")]
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
