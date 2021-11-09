using _03_ef_linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_ef_async
{
    class AcademyManager
    {
        private AcademyDb context;
        public AcademyManager()
        {
            context = new AcademyDb();
        }

        public async void ShowStudentsWithDelay()
        {
            var result = await context.Students.ToListAsync();
            foreach (var s in result)
            {
                Console.WriteLine($"Student: {s.FullName}\t{s.AverageMark}\t{s.Birthdate.ToShortDateString()}");
            }
        }
        public async Task<IEnumerable<Student>> GetStudentsWithDelay()
        {
            return await context.Students.ToListAsync();
        }
        public static Student SelectWithDelay(Student st)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10_000_000; i++)
            {
                rnd.Next();
                rnd.NextDouble();
            }
            return st;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AcademyManager manager = new AcademyManager();

            Console.WriteLine("Getting...");
            manager.ShowStudentsWithDelay();
            //var result = manager.GetStudentsWithDelay();

            Console.WriteLine("Done!");
            Console.ReadKey(); // pause
        }
        
    }
}
