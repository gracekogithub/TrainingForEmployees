using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Post
    {
        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
