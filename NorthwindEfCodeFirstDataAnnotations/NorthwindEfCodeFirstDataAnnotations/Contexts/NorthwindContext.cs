using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirstDataAnnotations.Entities;

namespace NorthwindEfCodeFirstDataAnnotations.Contexts
{
    public  class NorthwindContext:DbContext
    {
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
    }
}
