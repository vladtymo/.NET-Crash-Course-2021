using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _06_tpl_parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////// Invoke
            //Parallel.Invoke(
            //       () => Console.WriteLine("First Task!"),
            //       () => Console.WriteLine("Second Task!"),
            //       () => Console.WriteLine("Third Task!")
            //);

            /////////////////// For
            //for (int i = 1; i < 7; i++)
            //{
            //    Task.Run(() => ShowFactorial(i));
            //}

            // 1...7
            //Parallel.For(1, 8, ShowFactorial);

            //int[] numbers = new[] { 2, 4, 1, 5, 3 };
            //Parallel.ForEach(numbers, ShowFactorial);

            List<Author> authors = new List<Author>()
            {
                new Author() { Name = "Taras" },
                new Author() { Name = "Ivan" },
                new Author() { Name = "Lesia" },
                new Author() { Name = "Lina" },
                new Author() { Name = "Taras" },
                new Author() { Name = "Ivan" },
                new Author() { Name = "Lesia" },
                new Author() { Name = "Lina" },
                new Author() { Name = "Taras" },
                new Author() { Name = "Ivan" },
                new Author() { Name = "Lesia" },
                new Author() { Name = "Lina" },
                new Author() { Name = "Taras" },
                new Author() { Name = "Ivan" },
                new Author() { Name = "Lesia" },
                new Author() { Name = "Lina" }
            };

            ParallelLoopResult result = Parallel.ForEach(authors, ShowAverageRating);

            if (result.IsCompleted)
                Console.WriteLine("Completed!");
            else
                Console.WriteLine("Broken at iteration: " + result.LowestBreakIteration);

            Console.ReadKey();
        }

        static void ShowFactorial(int num)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100_000_000; i++)
            {
                rnd.Next(); rnd.NextDouble();
            }

            long res = 1;
            for (int i = 2; i <= num; i++)
            {
                res *= i;
            }
            Console.WriteLine($"Factorial of {num} = {res}");
        }
        static void ShowAverageRating(Author author, ParallelLoopState pls)
        {
            if (author.Name == "Lina") pls.Break(); // stop 
            Thread.Sleep(1000);
            Console.WriteLine($"Author: {author.Name} with rating {author.Ratings.Average()}");
        }
    }
    class Author
    {
        public string Name { get; set; }
        public int[] Ratings { get; set; }
        public Author()
        {
            Random rnd = new Random();
            Ratings = new int[5];
            for (int i = 0; i < Ratings.Length; i++)
            {
                Ratings[i] = rnd.Next(6);
            }
        }
    }
}
