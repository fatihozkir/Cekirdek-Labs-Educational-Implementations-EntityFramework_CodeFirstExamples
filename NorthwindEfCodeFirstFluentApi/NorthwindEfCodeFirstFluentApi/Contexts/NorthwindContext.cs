using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirstFluentApi.Entities;
using NorthwindEfCodeFirstFluentApi.Entities.EfCodeFirstMappings;

namespace NorthwindEfCodeFirstFluentApi.Contexts
{
    public class NorthwindContext:DbContext
    {
        //public NorthwindContext():base("Name=ContextConnectionString")
        //{
            
        //}

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
        }
    }
}
