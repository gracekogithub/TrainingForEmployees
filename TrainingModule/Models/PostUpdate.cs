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
        public string Daily { get; set; }
        public string DailyContent { get; set; }
        public DateTime DailyCreated { get; set; }
        public string Weekly { get; set; }
        public string WeeklyContent { get; set; }
        public DateTime WeeklyCreated { get; set; } 
        public string IdentityUserId { get; internal set; }
        [ForeignKey("Manager")]
        public Manager Manager { get; set; }
    }
}
