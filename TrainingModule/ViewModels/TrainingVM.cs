using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Models;

namespace TrainingModule.ViewModels
{
    public class TrainingVM
    {
        public Training Training { get; set; }
        public IEnumerable<SelectListItem> MaterialList { get; set; }
    }
}
