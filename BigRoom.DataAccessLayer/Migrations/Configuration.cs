using System.Data.Entity.Migrations;

namespace BigRoom.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BigRoomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BigRoomContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Users.AddOrUpdate(
            //    user => user.Email,
            //    new User { Name = "Jovan", Email = "jovan.juranovic@gmail.com", Password = "password123" }
            //    );
            //context.SaveChanges();
        }
    }
}
