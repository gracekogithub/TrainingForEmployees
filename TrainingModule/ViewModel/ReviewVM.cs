using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Models;

namespace TrainingModule.ViewModel
{
    public class ReviewVM
    {
        public Reviewer Reviewer { get; set; }
        public IEnumerable<SelectListItem> TrainingList { get; set; }
    }
}
