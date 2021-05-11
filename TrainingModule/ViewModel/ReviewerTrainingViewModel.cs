using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingModule.Models;

namespace TrainingModule.ViewModel
{
    public class ReviewerTrainingViewModel
    {
        public ICollection<Training> Trainings { get; set; }
        public ICollection<Reviewer> Reviewers { get; set; }
    }
}
