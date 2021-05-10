using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public List<Comment>? Comments { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
