using System;
using System.Linq;

namespace _02_ef_relations
{
    class Program
    {
        static void Main(string[] args)
        {
            MyShopDb db = new MyShopDb();

            db.Orders.First().Products.Add(db.Products.First());
            db.SaveChanges();

            foreach (var item in db.Users)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
