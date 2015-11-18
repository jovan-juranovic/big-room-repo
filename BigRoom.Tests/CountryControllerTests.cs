using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.Model;
using BigRoom.Service.Controllers.API;
using BigRoom.Service.Models.UserInfoVms;
using NSubstitute;
using NUnit.Framework;

namespace BigRoom.Tests
{
    [TestFixture]
    public class CountryControllerTests
    {
        [Test]
        public void GetCountry_WhenCalled_ReturnsCountry()
        {
            // Arrange
            Country country = new Country
            {
                Id = 1,
                Name = "TestCountry"
            };
            ICountryService fakeCountryService = Substitute.For<ICountryService>();
            fakeCountryService.GetCountries().Returns(new List<Country> {country});

            //Act
            CountriesController countriesController = new CountriesController(fakeCountryService);
            CountryVM result = countriesController.Get().First();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
