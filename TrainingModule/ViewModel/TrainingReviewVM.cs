using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingModule.ViewModel
{
    public class TrainingReviewVM
    {
        //[Key]
        //public int TrainingReviewVMId { get; set; }

        public virtual Training Training { get; set; }
        public virtual Reviewer Reviewer { get; set; }

        public IEnumerable<SelectListItem> ReviewList { get; set; }
        
    }
}
