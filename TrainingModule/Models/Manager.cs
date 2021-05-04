using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        [Required]
        public string ManagerFirstName { get; set; }
        [Required]
        public string ManagerLastName { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public virtual ICollection<ManagerFeedback> ManagerFeedbacks { get; set; }
        public virtual ICollection<ManagerUpdate> ManagerUpdates { get; set; }
        public virtual ICollection<ManagerTraining> ManagerTrainings { get; set; }
    }
}
