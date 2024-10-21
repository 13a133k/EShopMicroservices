namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon{ Id = 1,ProductName = "Iphone X",Description = "Iphone details",Amount = 1500},
            new Coupon{ Id = 2,ProductName = "Samsung S21",Description = "Iphone details",Amount = 1450} 
        );
    }

}