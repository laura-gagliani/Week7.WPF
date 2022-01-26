using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.EsercizioECommerce.Core.Entities;

namespace Week7.EsercizioECommerce.Core.Repositories
{
    public interface IProductRepository
    {
        IList<Product> FetchAll();
    }
}
