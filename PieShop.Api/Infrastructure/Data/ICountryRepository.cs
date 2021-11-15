using PieShop.Shared;
using System.Collections.Generic;

namespace PieShop.Api.Infrastructure.Data
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
