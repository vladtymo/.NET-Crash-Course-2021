using System.Collections.Generic;

namespace _02_ef_relations
{
    // One to One
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Credential Credential { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
