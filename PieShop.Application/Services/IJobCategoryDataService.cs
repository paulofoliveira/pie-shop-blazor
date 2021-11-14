using PieShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop.Application.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
}
