using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEfCodeFirst.Contexts;
using NorthwindEfCodeFirst.Entities;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //One();

            //Two();

            //Three();

            //Four();

            //Five();

            //Six();

            //Seven();

            //Eight();

            //Nine();

            //Ten();

            //Eleven();

            //Twelve();

            //Thirteen();

            //FourTeen();

            using (var northwindContext = new NorthwindContext())
            {
                //Eager Loading
                var result = northwindContext.Customers.Where(c=>c.CustomerID=="ALFKI").Include("Orders");

                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.ContactName, customer.Orders.Count);
                }
            }

            Console.ReadLine();
        }

        private static void FourTeen()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = northwindContext.Customers.
                    Where(c => c.City == "London" || c.Country == "UK").
                    OrderBy(c => c.ContactName).
                    Select(cus => new {cus.CustomerID, cus.ContactName});

                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.CustomerID, customer.ContactName);
                }
            }
        }

        private static void Thirteen()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             join o in northwindContext.Orders
                                 on c.CustomerID equals o.CustomerID into temp
                             from co in temp.DefaultIfEmpty()
                             //where temp.Count() == 0
                             select new
                                        {
                                            c.CustomerID,
                                            c.ContactName,
                                            c.CompanyName
                                        };

                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1},{2}",
                                      customer.CustomerID, customer.ContactName, customer.CompanyName);
                }

                Console.WriteLine("{0} adet kayıt vardır", result.Count());
            }
        }

        private static void Twelve()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             join o in northwindContext.Orders
                                 on
                                 new {c.CustomerID, Sehir = c.City}
                                 equals
                                 new {o.CustomerID, Sehir = o.ShipCity}
                             orderby c.CustomerID
                             select new
                                        {
                                            c.CustomerID,
                                            c.ContactName,
                                            o.OrderDate,
                                            o.ShipCity
                                        };


                foreach (var item in result)
                {
                    Console.WriteLine(
                        "{0},{1},{2},{3}",
                        item.CustomerID, item.ContactName, item.OrderDate, item.ShipCity);
                }

                Console.WriteLine("{0} adet sipariş vardır.", result.Count());
            }
        }

        private static void Eleven()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country.Length descending, c.ContactName ascending
                                         select c).ToList();

                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.Country, customer.ContactName);
                }
            }
        }

        private static void Ten()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by new { c.Country, c.City }
                                 into g
                                 select new
                                            {
                                                Sehir = g.Key.City,
                                                Ulke = g.Key.Country,
                                                Adet = g.Count()
                                            };

                foreach (var group in result)
                {
                    Console.WriteLine
                        ("Ulke : {0}, Şehir : {1}, Adet : {2}", @group.Ulke, @group.Sehir, @group.Adet);
                }
            }
        }

        private static void Nine()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by c.Country
                                 into g
                                 select g;

                foreach (var group in result)
                {
                    Console.WriteLine(@group.Key);
                }
            }
        }

        private static void Eight()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         where c.Country == "UK" || c.City == "Berlin"
                                         select c).ToList();

                foreach (var customer in result)
                {
                    Console.WriteLine("Contact Name : {0} , City :{1}", customer.ContactName, customer.City);
                }
            }
        }

        private static void Seven()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             select new Musteri { Ulke = c.Country, Sirket = c.CompanyName, Adi = c.ContactName };

                foreach (var musteri in result)
                {
                    Console.WriteLine(musteri.Sirket);
                }
            }
        }

        private static void Six()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         select c).ToList();

                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void Five()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGIN");

                customer.Country = "Turkey";

                northwindContext.SaveChanges();
            }
        }

        private static void Four()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Order order = northwindContext.Orders.Find(1);

                northwindContext.Orders.Remove(order);

                northwindContext.SaveChanges();
            }
        }

        private static void Three()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGIN");
                customer.Orders.Add(
                    new Order
                        {
                            OrderID = 1,
                            OrderDate = DateTime.Now,
                            ShipCity = "Ankara",
                            ShipCountry = "Türkiye"
                        });
                northwindContext.SaveChanges();
            }
        }

        private static void Two()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var customer = new Customer
                                   {
                                       CustomerID = "ENGIN",
                                       City = "Ankara",
                                       CompanyName = "YazilimDevi.Com",
                                       ContactName = "Engin Demiroğ",
                                       Country = "Türkiye"
                                   };
                northwindContext.Customers.Add(customer);
                northwindContext.SaveChanges();
            }
        }

        private static void One()
        {
            using (var northwindContext = new NorthwindContext())
            {
                foreach (var customer in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }
            }
        }
    }

    internal class Musteri
    {
        public string Ulke { get; set; }

        public string Sirket { get; set; }

        public string Adi { get; set; }
    }
}
