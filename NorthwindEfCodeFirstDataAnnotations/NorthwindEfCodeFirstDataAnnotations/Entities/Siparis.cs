using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEfCodeFirstDataAnnotations.Entities
{
    [Table("Orders")]
    public class Siparis
    {
        [Column("OrderID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Kod { get; set; }

        [Column("CustomerID")]
        public string MusteriKod { get; set; }

        [ForeignKey("MusteriKod")]
        public Musteri Musteri { get; set; }

        //Diğer

    }
}
