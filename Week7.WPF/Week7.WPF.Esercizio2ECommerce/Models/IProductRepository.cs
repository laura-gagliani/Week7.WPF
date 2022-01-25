using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercizio2ECommerce.Models
{
    public interface IProductRepository
    {
        IList<Product> FetchAll();
    }
}
