using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingModule.Models
{
    public class FileHelper
    {
        public int FileId { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public List<FileHelper> Files { get; set; } = new List<FileHelper>();
    }
}
