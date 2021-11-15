using PieShop.Shared;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Api.Infrastructure.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly PieShopContext _appDbContext;

        public CountryRepository(PieShopContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
