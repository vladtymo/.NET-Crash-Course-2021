using System;
using System.Linq;

namespace _01_ef_code_first
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext context = new MyDbContext();

            // Add
            context.Countries.Add(new Country() { Name = "Russia" });
            context.SaveChanges(); 

            // Edit
            Country element = context.Countries.First(c => c.Name == "Russia");
            element.Name = "Blabla";

            // Delete
            context.Countries.Remove(element);

            context.SaveChanges(); // apply all changes to remote server

            foreach (Country c in context.Countries)
            {
                Console.WriteLine("Country: " + c.Name);
            }
        }
    }
}
