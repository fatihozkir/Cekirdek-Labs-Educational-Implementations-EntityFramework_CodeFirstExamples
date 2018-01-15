using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEfCodeFirstFluentApi.Entities.EfCodeFirstMappings
{
    public class OrderMap:EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(t => t.OrderID);

            this.Property(t => t.CustomerID).
                IsFixedLength().
                HasMaxLength(5);

            this.ToTable("Orders");

            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");

            this.HasOptional(t => t.Customer).
                WithMany(t => t.Orders).
                HasForeignKey(d => d.CustomerID);

        }
    }
}
