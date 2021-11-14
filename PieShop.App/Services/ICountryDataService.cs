using PieShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop.Application.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
