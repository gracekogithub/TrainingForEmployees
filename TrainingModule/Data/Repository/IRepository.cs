
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingModule.Models;
using TrainingModule.ViewModels;

namespace Blog.Data.Repository
{
    public interface IRepository
    {

        void RemovePost(int id);

        Task<bool> SaveChangesAsync();
    }
}
