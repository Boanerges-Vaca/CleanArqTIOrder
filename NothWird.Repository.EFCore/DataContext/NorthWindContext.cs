using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.DataContext
{
    public class NorthWindContext: DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :
            base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();

            model.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            model.Entity<Product>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            model.Entity<Order>()
                .Property(c => c.CustomerId)
                .IsRequired()
                .HasMaxLength(5);

            model.Entity<Order>()
                .Property(c => c.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            model.Entity<Order>()
                .Property(c => c.ShipCity)
                .HasMaxLength(15);

            model.Entity<Order>()
                .Property(c => c.ShipCountry)
                .HasMaxLength(15);

            model.Entity<Order>()
                .Property(c => c.ShipCountry)
                .HasMaxLength(10);

            model.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            model.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            model.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            model.Entity<Product>()
                .HasData(
                    new Product { Id= 1, Name= "Chai"},
                    new Product { Id = 2, Name = "Chang" },
                    new Product { Id = 3, Name = "Aniseed Syrup" }
                );

            model.Entity<Customer>()
                .HasData(
                    new Customer { Id ="ALFKI", Name="Alfreds"},
                    new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                    new Customer { Id = "ANTON", Name = "Antornio Moren" }
                );

        }

    }
}
