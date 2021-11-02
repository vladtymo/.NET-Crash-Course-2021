using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ef_relations
{
    class MyShopDb : DbContext
    {
        public MyShopDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=MyShopDb;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //////////////////////// Seed Data
            User user = new User()
            {
                Id = 1,
                FirstName = "Igor",
                LastName = "Martyn",
            };
            Credential credential = new Credential()
            { 
                Login = "super_programmer",
                Password = "qwerty",
                UserId = 1
            };

            var products = new[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Ball",
                    Price = 340,
                    Quantity = 45
                },
                new Product()
                {
                    Id = 2,
                    Name = "Net",
                    Price = 560,
                    Quantity = 12
                }
            };

            Order order = new Order()
            {
                Number = 1000,
                TotalPrice = 1350,
                UserId = 1,
                //Date = ...
                //Products = new List<Product>()
                //{
                //    products[0], products[1]
                //}
            };

            #region FluentAPI Configurations
            //////////////////// Credential Configurations
            modelBuilder.Entity<Credential>().Property(u => u.Login)
                                            .IsRequired()
                                            .HasMaxLength(100);
            modelBuilder.Entity<Credential>().Property(u => u.Password)
                                            .IsRequired()
                                            .HasMaxLength(50);
            // Relationship: One to One
            modelBuilder.Entity<Credential>().HasKey(o => o.UserId);
            modelBuilder.Entity<Credential>().HasOne<User>(c => c.User)
                                             .WithOne(u => u.Credential)
                                             .HasForeignKey<Credential>(c => c.UserId);

            //////////////////// User Configurations
            modelBuilder.Entity<User>().Property(u => u.FirstName)
                                            .IsRequired()
                                            .HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.LastName)
                                            .IsRequired()
                                            .HasMaxLength(200);
            // Relationship: One to Many
            modelBuilder.Entity<User>().HasMany(u => u.Orders)
                                       .WithOne(o => o.User)
                                       .HasForeignKey(o => o.UserId);

            //////////////////// Order Configurations
            modelBuilder.Entity<Order>().HasKey(o => o.Number);
            modelBuilder.Entity<Order>().Property(o => o.Date).HasDefaultValue(DateTime.Now); // ???

            // Relationship: Many to Many
            modelBuilder.Entity<Order>().HasMany(o => o.Products)
                                        .WithMany(p => p.Orders);

            //////////////////// Product Configurations
            modelBuilder.Entity<Product>().Property(u => u.Name)
                                          .IsRequired()
                                          .HasMaxLength(150);
            #endregion

            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<Credential>().HasData(credential);
            modelBuilder.Entity<Order>().HasData(order);
            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
