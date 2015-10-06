using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.Service.Common;
using BigRoom.Service.Models.UserInfoVms;

namespace BigRoom.Service.Controllers.API
{
    public class CountriesController : BaseApiController
    {
        #region Fields

        private readonly ICountryService countryService;

        #endregion

        #region Ctor's

        public CountriesController()
        {
            this.countryService = new CountryService();
        }

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        #endregion

        #region API

        public IEnumerable<CountryVM> Get()
        {
            return this.countryService.GetCountries().Select(country => new CountryVM
            {
                Id = country.Id,
                Name = country.Name,
                Code = country.IsoCountryCode
            }).ToList();
        }

        #endregion
    }
}
