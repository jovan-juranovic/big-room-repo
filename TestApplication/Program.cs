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
            ProductReviewService ps = new ProductReviewService();

            ProductReview p = new ProductReview
            {
                Title = "Test",
                Comment = "Test",
                Approved = false,
                PostingDate = DateTime.Now,
                ProductId = 31,
                UserId = 5,
                Rating = 5
            };

            bool result = ps.InsertReview(p);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
