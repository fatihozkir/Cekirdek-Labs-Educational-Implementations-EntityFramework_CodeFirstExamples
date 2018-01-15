using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirstMigration.Contexts;
using NorthwindEfCodeFirstMigration.Migrations;

namespace NorthwindEfCodeFirstMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindContext,Configuration>());

            using (var context=new NorthwindContext())
            {
                foreach (var customer in context.Customers)
                {
                    Console.WriteLine(customer.ContactName);
                }

               
            }

        }
    }
}
