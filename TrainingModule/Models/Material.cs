using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class Material
    {
       
        public int MaterialId { get; set; }
        
        public string TrainingFormat { get; set; }
       
        public virtual Training Trainings { get; set; }

        //public List<SelectListItem> GetAllTrainingMaterial()
        //{
        //    List<SelectListItem> trainingList = new List<SelectListItem>();
        //    var data = new[]
        //    {
        //        new SelectListItem { Value = "1", Text = "Pdf file" },
        //        new SelectListItem { Value = "1", Text = "Image file" }
        //    };
        //    trainingList = data.ToList();
        //    return trainingList;
        //}
    }
}
