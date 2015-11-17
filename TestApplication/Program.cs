using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BigRoom.BusinessLayer;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string creds = "jovan.juranovic@gmail.com:password123".ToBase64String();
            CountryService cs = new CountryService();
            Console.WriteLine(cs.GetCountries().First().Name);
            Console.ReadLine();
        }
    }
}
