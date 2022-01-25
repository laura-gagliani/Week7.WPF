using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercizio2ECommerce.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>()
        {
            new Product() {Name = "Nike Sneakers", Description = "White faux leather", Price = 89.90},
            new Product() {Name = "Chanel Boots", Description = "Are you wearing the...", Price = 9999.99}
        };

        public IList<Product> FetchAll()
        {
            return _products;
        }
    }
}
