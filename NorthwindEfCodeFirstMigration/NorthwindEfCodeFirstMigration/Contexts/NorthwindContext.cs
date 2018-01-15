using System.Data.Entity;
using NorthwindEfCodeFirstMigration.Entities;

namespace NorthwindEfCodeFirstMigration.Contexts
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
