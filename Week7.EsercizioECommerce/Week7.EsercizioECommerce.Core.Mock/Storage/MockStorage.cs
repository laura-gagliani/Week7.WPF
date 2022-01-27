using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.EsercizioECommerce.Core.Entities;

namespace Week7.EsercizioECommerce.Core.Mock.Storage
{
    public class MockStorage
    {
        public static List<User> Users { get; set; }

        public static List<Product> Products { get; set; }

        public static void Initialize()
        {
            //creazione della lista vuota
            Users = new List<User>();

            //aggiunta utenti di default
            Users.Add(new User() { Id = 1, UserName = "mario.rossi", Password = "12345", Email = "mario@gmail.com" });
            Users.Add(new User() { Id = 2, UserName = "giuseppe.verdi", Password = "abcde", Email = "giuseppe@gmail.com" });


            Products = new List<Product>();

            Products.Add(new Product() {Name= "Shoe x", Description = "...", Price = 56.80 });
            Products.Add(new Product() {Name= "Shoe y", Description = "...", Price = 32.00 });
            Products.Add(new Product() {Name= "Shoe z", Description = "...", Price = 99.90 });

        }
    }
}
