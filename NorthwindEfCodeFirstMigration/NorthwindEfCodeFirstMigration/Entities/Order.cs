using System;

namespace NorthwindEfCodeFirstMigration.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string CustomerID { get; set; }

        public Customer Customer { get; set; }
    }
}