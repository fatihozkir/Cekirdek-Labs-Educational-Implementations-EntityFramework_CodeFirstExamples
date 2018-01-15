using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirstFluentApi.Contexts;

namespace NorthwindEfCodeFirstFluentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var nortwindContext=new NorthwindContext())
            {
                foreach (var customer in nortwindContext.Customers)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }

            Console.ReadLine();
        }
    }
}
