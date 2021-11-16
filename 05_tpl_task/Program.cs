using System;
using System.Threading.Tasks;

namespace _05_tpl_task
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowNumber();
            //ShowNumber();
            //ShowNumber();

            //--------------------------------------
            ////////////// Create a new Task and Run

            //Task task1 = new Task(ShowNumber);
            //task1.Start();

            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Hello from task 2!"));

            //Task task3 = Task.Run(() => Console.WriteLine("Hello from task 3!"));

            //--------------------------------------
            ///////////////////// The array of tasks

            //ShowFactorial(5);
            //ShowFactorial(4);
            //ShowFactorial(7);

            //Task[] tasks = new Task[]
            //{
            //    Task.Run(() => ShowFactorial(5)),
            //    Task.Run(() => ShowFactorial(4)),
            //    Task.Run(() => ShowFactorial(7))
            //};

            //Task.WaitAny(tasks);
            //Console.WriteLine("Some task has completed!");

            //tasks[0].Wait();
            //Console.WriteLine("Task 1 has completed!");

            //Task.WaitAll(tasks);
            //Console.WriteLine("All tasks have completed!");

            //---------------------------------------
            /////////////////////// Task return value

            //Task<long> task = Task.Run(() => GetFactorial(6));
            //Console.WriteLine("Waiting...");

            ////task.Wait(); // pause current thread until the task complete
            //Console.WriteLine("Result: " + task.Result);

            //ShowFactorialAsync(8);
            //long res = GetFactorialAsync(8).Result; // pause until complete
            //Console.WriteLine("Result: " + res);

            TestAsyncMethod();
            
            Console.WriteLine("End the main thread!");
            Console.ReadKey(); // pause
        }

        static async void TestAsyncMethod()
        {
            long res = await GetFactorialAsync(8);
            Console.WriteLine("Result: " + res);
        }

        static void ShowNumber()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void ShowFactorial(int num)
        {
            Console.WriteLine($"Factorial of {num} = {GetFactorial(num)}");
        }
        static long GetFactorial(int num)
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
            return res;
        }

        static void ShowFactorialAsync(int num)
        {
            Task.Run(() =>
            {
                Console.WriteLine($"Factorial of {num} = {GetFactorial(num)}");
            });
        }
        static Task<long> GetFactorialAsync(int num)
        {
            return Task.Run(() =>
            {
                return GetFactorial(num);
            });
        }
    }
}
