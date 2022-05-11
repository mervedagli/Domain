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
        private const string ConnectionString = "Data Source=.; Initial Catalog=IgdasDomainProject; Integrated Security=true;";

        public DataContext()
        {

        }

        //public DataContext(DbContextOptions options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("name=DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(false) // nvarchar değil de varchar tipi istiyorsanız
                //.HasColumnType("varchar(50)") // üstteki iki satır yerine geçecektir
                .IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany<OrderDetail>()
                .WithOne()
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.OrderDate);//.IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.Status);//.IsRequired();



            //modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderId);
            var orderDetailBuilder = modelBuilder.Entity<OrderDetail>();

            orderDetailBuilder.HasKey(entity => new
            {
                entity.OrderId,
                entity.ProductId
            });

            orderDetailBuilder.HasOne(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderId);

            //orderDetailBuilder.HasOne(od => od.Product)

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
