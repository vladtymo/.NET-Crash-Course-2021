using System;
using System.Collections.Generic;

namespace _02_ef_relations
{
    // One to Many (One User has Many Orders)
    class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }
        public int Number { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
