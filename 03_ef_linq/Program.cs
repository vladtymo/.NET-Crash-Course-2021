using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ef_linq
{
    class AcademyManager
    {
        private AcademyDb context;
        public AcademyManager()
        {
            context = new AcademyDb();
        }

        // Queries
        // Get, Create, Fillters...
        public IEnumerable<Student> GetTopStudents(int count)
        {
            return context.Students.OrderByDescending(s => s.AverageMark).Take(count).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AcademyDb db = new AcademyDb();

            // LINQ - Language Integrated Query

            IEnumerable<Student> res = db.Students; // all students

            // Join with relative objects
            //res = db.Students.Include(s => s.Group);

            // Filtering
            //res = db.Students.Where(IsSuccessStudent).ToList();
            //res = db.Students.Where((s) => s.AverageMark >= 10);
            //res = db.Students.Where(s => s.Birthdate.Year >= 2000 && s.Birthdate.Year <= 2005);
            //res = db.Students.Where(s => s.FirstName.StartsWith("A"));
            //res = db.Students.Include(s => s.Group).Where(s => s.Group.Name == "Jaloo");

            // Sorting
            //res = db.Students.OrderBy(s => s.AverageMark);
            //res = db.Students.OrderByDescending(s => s.AverageMark);
            //res = db.Students.OrderByDescending(s => s.AverageMark).Take(3);

            ShowStudentsWithGroups(res.ToList());
            
            // Mapping
            //var names = db.Students.Where(s => s.AverageMark >= 10).Select(s => s.FullName);

            // Calculating (Count, Sum, Average, Min, Max)
            //var res = db.Students.Count();
            //res = db.Students.Where(s => s.GroupId == 3).Count());
            //res = db.Students.Count(s => s.AverageMark < 7);
            //var res = db.Students.Where(s => s.Group.Name == "Jabbersphere").Average(s => s.AverageMark);
            
            //Console.WriteLine("Count: " + res);

            // Grouping
            var groups  = db.Students.ToList().GroupBy(s => s.GroupId);
            foreach (var group in groups)
            {
                Console.WriteLine($"--------- {group.Key}: {group.Count()} ----------");
                foreach (var s in group)
                {
                    Console.WriteLine(s.FullName);
                }
            }
        }
        static void ShowStudentsWithGroups(IEnumerable<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"Student: {s.FullName}\t|" +
                    $"{s.Group.Name}\t|" +
                    $"{s.AverageMark}\t|" +
                    $"{s.Birthdate.ToShortDateString()}");
            }
        }
        static void ShowStudents(IEnumerable<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"Student: {s.FullName}\t{s.AverageMark}\t{s.Birthdate.ToShortDateString()}");
            }
        }

        static bool IsSuccessStudent(Student st)
        {
            return st.AverageMark >= 10;
        }
    }
}
