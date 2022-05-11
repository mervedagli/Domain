using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();

            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.OrderDate).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.Status).IsRequired();

            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderId);  
            modelBuilder.Entity<OrderDetail>()
            .HasOne<Order>(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => new { x.OrderId, x.ProductId });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
