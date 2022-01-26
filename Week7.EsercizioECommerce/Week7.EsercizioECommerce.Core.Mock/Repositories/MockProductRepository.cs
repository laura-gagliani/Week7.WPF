using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.EsercizioECommerce.Core.Entities;
using Week7.EsercizioECommerce.Core.Mock.Storage;
using Week7.EsercizioECommerce.Core.Repositories;

namespace Week7.EsercizioECommerce.Core.Mock.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        public IList<Product> FetchAll()
        {
            return MockStorage.Products;
        }


    }
}
