using System.Data.Entity;
using BigRoom.Model;

namespace BigRoom.DataAccessLayer
{
    public class BigRoomContext : DbContext
    {
        public BigRoomContext() : base("BigRoomDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BigRoomContext, Migrations.Configuration>());
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
