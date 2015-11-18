using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        Country FindCountry(int id);
    }
}