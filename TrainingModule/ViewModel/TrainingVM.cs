using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainingModule.Models;

namespace TrainingModule.ViewModel
{
    public class TrainingVM
    {
        public Training Training { get; set; }
        public IEnumerable<SelectListItem> MaterialList { get; set; }
    }
}
