using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Comment
    {
        public int Id
        {
            get; set;
        }
        public string Message
        {
            get; set;
        }
        public DateTime Created
        {
            get; set;
        }
        //public int TrainingId { get; set; }
        //public virtual Training Trainings { get; set; }
     
    }
}
