using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirstDataAnnotations.Contexts;
using NorthwindEfCodeFirstDataAnnotations.Entities;

namespace NorthwindEfCodeFirstDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var northwindContext=new NorthwindContext())
            {
                List<Musteri> musteriler = northwindContext.Musteriler.ToList();

                foreach (var musteri in musteriler)
                {
                    Console.WriteLine("{0}", musteri.Ad);
                }


            }

            Console.ReadLine();
        }
    }
}
