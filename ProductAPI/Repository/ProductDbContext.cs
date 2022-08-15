using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Repository
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> GetAll { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.Property(e => e.ProductName)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.ProductFeatures)
        //            .IsRequired()
        //            .HasMaxLength(250)
        //            .IsUnicode(false);

                
        //    });
        //}
    }
}
