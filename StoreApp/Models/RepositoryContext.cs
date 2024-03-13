using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }

        // protected:kalıtım ögesi erişim
        // override: dbcontext methodu ustune yazım
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // db create işleminde veri yok ise bunlar default yazılı olacak
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() {ProductId=1, ProductName="test", Price=10_000},
                    new Product() {ProductId=2, ProductName="test2", Price=20_000},
                    new Product() {ProductId=3, ProductName="test3", Price=30_000}
                );
        }

    }
}