using PieShop.Shared;
using System.Collections.Generic;

namespace PieShop.Api.Infrastructure.Data
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
