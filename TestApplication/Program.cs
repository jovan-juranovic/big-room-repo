using System;
using System.Linq;
using BigRoom.BusinessLayer;
using BigRoom.BusinessLayer.Services;
using BigRoom.Model;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryService cs = new CountryService();

            Console.WriteLine(cs.GetCountries().First().Name);

            Console.ReadLine();
        }
    }
}
