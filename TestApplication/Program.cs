using System;
using System.Linq;
using BigRoom.BusinessLayer;
using BigRoom.Model;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductReviewService ps = new ProductReviewService();

            ProductReview p = ps.GetReviewsByProduct(31).First();

            Console.WriteLine(p.Title);

            Console.ReadLine();
        }
    }
}
