using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEfCodeFirstDataAnnotations.Entities
{
    [ComplexType]
    public class MusteriSiparisDTO
    {
        public string CustomerID { get; set; }

        public int OrderID { get; set; }

        //Diğer 

    }
}
