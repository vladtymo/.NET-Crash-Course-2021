using System.Collections.Generic;

namespace _02_ef_relations
{
    // Many to Many
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
