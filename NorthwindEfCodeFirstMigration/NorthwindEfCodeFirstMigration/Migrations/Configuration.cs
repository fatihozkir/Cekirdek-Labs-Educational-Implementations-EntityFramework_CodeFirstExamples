using System.Collections.Generic;
using NorthwindEfCodeFirstMigration.Entities;

namespace NorthwindEfCodeFirstMigration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindEfCodeFirstMigration.Contexts.NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NorthwindEfCodeFirstMigration.Contexts.NorthwindContext";
        }

        protected override void Seed(NorthwindEfCodeFirstMigration.Contexts.NorthwindContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var customers = new List<Customer> {new Customer
                                                    {
                                                        CustomerID = "AHMET", City = "Istanbul", Address = "İstanbul", ContactName = "Ahmet", Country = "Türkiye", Title = "Doktor"
                                                    },
            new Customer
                                                    {
                                                        CustomerID = "ENGIN", City = "Bursa", Address = "İstanbul", ContactName = "Engin Demiroğ", Country = "Türkiye", Title = "Doktor"
                                                    }
            };


            context.Customers.AddOrUpdate(c => new { c.CustomerID }, customers.ToArray());
        }
    }
}
