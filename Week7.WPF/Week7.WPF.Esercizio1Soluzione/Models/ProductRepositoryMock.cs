using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercizio1Soluzione.Models
{
    public class ProductRepositoryMock : IProductsRepository
    {
        private IList<Product> products = new List<Product>()
        {
            new Product() { Name = "Smartphone", Description="Samsung S3853", Price = 640.99},
            new Product() { Name = "Chanel bag", Description="Black leather - mini size", Price = 1200}
        };
        public IList<Product> GetAll()
        {
            return products;
        }
    }
}
