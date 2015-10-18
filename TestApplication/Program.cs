using System;
using System.Collections.Generic;
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
            //CartService cs = new CartService();

            //Cart cart = new Cart
            //{
            //    Subtotal = 100,
            //    ShippingTotal = 10,
            //    TotalAmount = 110,
            //    Comment = "test",
            //    Status = CartStatus.Open,
            //    OrderDate = DateTime.Now,
            //    OrderNumber = Guid.NewGuid(),
            //    UserId = 1,
            //    CartItems = new List<CartItem>
            //    {
            //        new CartItem
            //        {
            //            Quantity = 1,
            //            Price = 100,
            //            ShippingPrice = 10,
            //            TotalPrice = 110,
            //            Comment = "test",
            //            ProductId = 31
            //        }
            //    }
            //};

            CountryService cs = new CountryService();

            Console.WriteLine(cs.GetCountries().First().Name);
            Console.ReadLine();
        }
    }
}
