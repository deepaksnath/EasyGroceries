using Microsoft.EntityFrameworkCore;
using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Data
{
    public class EasyDBContext : DbContext
    {
        public EasyDBContext(DbContextOptions<EasyDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();
            modelBuilder.Entity<Order>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();
            modelBuilder.Entity<Customer>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();
            modelBuilder.Entity<OrderItem>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();
        }
    }
}
