using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ef_code_first
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"data source=(localdb)\MSSQLLocalDB;initial catalog=AirlinesDb09;integrated security=True;"
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=MyCompanyDb;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data
            modelBuilder.Entity<Country>()
                .HasData(new Country() { Id = 1, Name = "Ukraine" },
                         new Country() { Id = 2, Name = "France" },
                         new Country() { Id = 3, Name = "Poland" });
        }

        // Database Collection
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }

    // Entities
    public class Worker
    {
        // Primary Key convension: Id/id/ID EntityName+Id
        //[Key] // primary key
        public int Id { get; set; }
        [Required] // not null
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        // Navigation Properties
        // Relationship type: One to Many (1...*)
        [Required]
        public Department Department { get; set; }

        // Relationship type: Zero or One to Many (0/1...*)
        public Country Country { get; set; }

        // Relationship type: Many to Many (*...*)
        public ICollection<Project> Projects { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? LaunchDate { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
