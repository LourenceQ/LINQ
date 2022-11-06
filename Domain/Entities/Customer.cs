using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Purchase> Purchases { get; set; }
    }
}