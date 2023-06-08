namespace Delivery_order.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DeliveryEmployee> DeliveryEmployees { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPay> ItemPay { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Qote> Qote { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<ShopDescription> ShopDescription { get; set; }
        public DbSet<ShopType> ShopTypes { get; set; }
        public DbSet<VMSUserLocation> UserLocation { get; set; }
        public DbSet<Region> Regions { get; set; }
      
    }
}