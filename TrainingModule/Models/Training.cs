using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace TrainingModule.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] File { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
