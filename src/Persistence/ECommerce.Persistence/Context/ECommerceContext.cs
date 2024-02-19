using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Context
{
    public class ECommerceContext:DbContext
    {
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLogin> CustomerLogins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLogin> EmployeeLogins { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }


        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany<EmployeeLogin>(x => x.EmployeeLogins)
                .WithOne(x => x.Role)
                .HasForeignKey(fk => fk.RoleID);


            modelBuilder.Entity<EmployeeLogin>()
                .HasOne<Employee>(x => x.Employee)
                .WithOne(y => y.EmployeeLogin)
                .HasForeignKey<EmployeeLogin>(fk => fk.PersonID);

            modelBuilder.Entity<BankCard>()
                .HasOne<EmployeeLogin>(x => x.EmployeeLogin)
                .WithOne(y => y.BankCard)
                .HasForeignKey<BankCard>(fk => fk.CardOwner);

            modelBuilder.Entity<CustomerLogin>()
                .HasOne<Customer>(x => x.Customer)
                .WithOne(y => y.CustomerLogin)
                .HasForeignKey<CustomerLogin>(fk => fk.PersonID);

            modelBuilder.Entity<CustomerLogin>()
                .HasMany<BankCard>(x => x.BankCards)
                .WithOne(y => y.CustomerLogin)
                .HasForeignKey(fk => fk.CardOwner);

            modelBuilder.Entity<CustomerLogin>()
                .HasMany<Invoice>(x => x.Invoices)
                .WithOne(y => y.Customer)
                .HasForeignKey(fk => fk.ID);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(fk => fk.CategoryID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>(x => x.Product)
                .WithMany(y => y.OrderDetails)
                .HasForeignKey(fk => fk.ProductID);

            modelBuilder.Entity<Invoice>()
                .HasOne<Order>(x => x.Order)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(fk => fk.OrderID);

            modelBuilder.Entity<Order>()
                .HasMany<OrderDetail>(x => x.OrderDetails)
                .WithOne(y => y.Order)
                .HasForeignKey(fk => fk.OrderID);
        }

    }
}
