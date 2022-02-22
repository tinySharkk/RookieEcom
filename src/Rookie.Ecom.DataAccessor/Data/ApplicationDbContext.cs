using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //code first
            //db first
            //model first
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "Category");
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable(name: "Product");
            });

            builder.Entity<Address>(entity =>
            {
                entity.ToTable(name: "Address");
            });

            builder.Entity<Cart>(entity =>
            {
                entity.ToTable(name: "Cart");
            });

            builder.Entity<City>(entity =>
            {
                entity.ToTable(name: "City");
            });

            builder.Entity<Order>(entity =>
            {
                entity.ToTable(name: "Order");
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable(name: "OrderItem");
            });

            builder.Entity<ProductImage>(entity =>
            {
                entity.ToTable(name: "ProductImage");
            });

            builder.Entity<Rating>(entity =>
            {
                entity.ToTable(name: "Rating");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<UserAccount>(entity =>
            {
                entity.ToTable(name: "UserAccount");
            });
        }
    }
}
