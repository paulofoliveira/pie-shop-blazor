using PieShop.Shared;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Api.Infrastructure.Data
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly PieShopContext _appDbContext;

        public JobCategoryRepository(PieShopContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _appDbContext.JobCategories;
        }

        public JobCategory GetJobCategoryById(int jobCategoryId)
        {
            return _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
        }
    }
}
