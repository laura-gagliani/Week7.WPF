using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercizio1Soluzione.Models
{
    public interface IProductsRepository
    {
        public IList<Product> GetAll();
    }
}
