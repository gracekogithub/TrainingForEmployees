using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class PostUpdate
    {
        public int PostUpdateId { get; set; }
        public string Daily { get; set; }
        public string DailyContent { get; set; }
        public DateTime DailyCreated { get; set; } = DateTime.Now;
        public string Weekly { get; set; }
        public string WeeklyContent { get; set; }
        public DateTime WeeklyCreated { get; set; } = DateTime.Now;
        public string IdentityUserId { get; internal set; }
    }
}
