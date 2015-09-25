using System;
using System.Linq;
using BigRoom.DataAccessLayer;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BigRoomContext())
            {
                var name = ctx.Countries.Single(c => c.Id == 206).Name;
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }
    }
}
