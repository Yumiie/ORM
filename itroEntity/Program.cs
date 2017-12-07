using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace itroEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                //select *
                var r1 = from c in db.Customers
                         select c;

                var r1bis = db.Customers;


                //select where avec moins de colonnes
                var r2 = from c in db.Customers
                         where c.Country == "France"
                         select c.CompanyName;

                var r2bis = db.Customers
                    .Where(c => c.Country == "France" && c.City == "Nantes")
                    .Select(c => c.CompanyName);


                //Select where avec moins de colones 
                var r3 = from c in db.Customers
                         where c.Country == "France" && c.City == "Nantes"
                         select new {c.CompanyName, c.ContactName };

                var r3bis = db.Customers 
                    .Where(c => c.Country == "France" && c.City == "Nantes") 
                    .Select(c => new { c.CompanyName, c.ContactName });


                //passer d'entity à un autre type d'objet
                var r4 = from c in db.Customers
                         where c.Country == "France" && c.City == "Nantes"
                         select new Chaton() { Nom = c.CompanyName, Origine = c.ContactName };

                var r4bis = db.Customers
                    .Where(c => c.Country == "France" && c.City == "Nantes")
                    .Select(c => new Chaton() { Nom = c.CompanyName, Origine = c.ContactName });


                //join
                var r5 = from o in db.Orders
                         join c in db.Customers
                            on o.CustomerID equals c.CustomerID
                         select new { o.OrderID, c.CompanyName };

                var r5bis = db.Orders.Join(
                    db.Customers,
                    o => o.CustomerID,
                    c => c.CustomerID,
                    (o, c) => new { o.OrderID, c.CompanyName });

                var r5Mieux = from o in db.Orders
                              select new
                              {
                                  o.OrderID,
                                  o.Customers.CompanyName
                              };

                var r5MieuxBis = db.Orders.Select(o => new
                {
                    o.OrderID,
                    o.Customers.CompanyName
                });

                // A NE PAS FAIRE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                var r6 = db.Orders;

                //foreach (var item in r6)
                //{
                //    WriteLine($"{item.OrderID} {item.Customers.CompanyName}"); //
                //}


                // Group by
                var r7 = from c in db.Customers
                         group c by c.Country into g    //on nomme le groupe
                         select new                     
                             {
                                 g.Key,                     //on nomme la propriété aggrégée (ici Nombre)
                                 Nombre = g.Count()         
                             };

                var r7bis = db.Customers.GroupBy(c => c.Country)
                    .Select(g => new
                    {
                        g.Key,
                        Nombre = g.Count()
                    });


                // Procédures stockées
                //var r8 = db.CAClientPourUnPays("France");

                //foreach (var item in r8)
                //{
                //    WriteLine ($"{item.CompanyName} {item.CA}");
                //}


                foreach (var item in r5)
                {
                    WriteLine($"{item.CompanyName} {item.OrderID}");
                }

                //Insert
                var categorie = new Categories()
                {
                    CategoryName = "Salades",
                    Description = " Des salades pour Pablo"
                };
                db.Categories.Add(categorie);
                db.SaveChanges();

                //Update
                var produit = db.Products.Find(3);
                produit.ProductName = " Sodebo soleil d'été";
                db.SaveChanges();

                //Delete 
                if (db.Categories.Any(c=>c.CategoryName=="Salades"))
                {
                    var categorieASupprimer = db.Categories
                                .First (c => c.CategoryName == "Salades");
                    db.Categories.Remove(categorieASupprimer);
                    db.SaveChanges(); 
                }


 
 //               foreach (var item in r4bis)
 //               {
 //                   WriteLine(item.Origine);
 //               }
//
 //               foreach (var item in r3)
 //               {
 //                   WriteLine(item);
 //               }
//
 //               foreach (var item in r2)
 //               {
 //                   WriteLine(item);
 //               }
//
 //               foreach (var item in r1)
 //               {
 //                   Console.WriteLine(item.CompanyName);
 //               }
//
                ReadKey();
            }
        }
    }
}
