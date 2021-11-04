using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ef_linq
{
    class AcademyDb : DbContext
    {
        public AcademyDb()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=AcademyDb2;integrated security=true;");
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }
        [NotMapped] // FluentAPI: Ignore()
        public string FullName => $"{FirstName} {LastName}";
        public DateTime Birthdate { get; set; }
        public float? AverageMark { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
