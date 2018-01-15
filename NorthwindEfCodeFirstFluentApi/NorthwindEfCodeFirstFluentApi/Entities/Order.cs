using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindEfCodeFirstFluentApi.Entities
{
    public class Order
    {
        
        public int OrderID { get; set; }
        
        public string CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }

    }
}
