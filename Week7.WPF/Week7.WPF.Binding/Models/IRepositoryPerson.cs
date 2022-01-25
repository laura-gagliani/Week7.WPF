using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Binding.Models
{
    public interface IRepositoryPerson
    {
        IList<Person> GetAll();
    }
}
