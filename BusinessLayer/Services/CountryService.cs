using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class CountryService : ICountryService
    {
        public IEnumerable<Country> GetCountries()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CountryRepository.GetAll(orderBy: o => o.OrderBy(c => c.Name));
            }
        } 
    }
}
