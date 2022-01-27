using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public void Create(Employee employee)
        {
            //creiamo qui il nuovo id (simuliamo vero DB)
            int newId = AllocationMockStorage.Employees.Max(x=> x.Id) +1;

            employee.Id = newId;
            AllocationMockStorage.Employees.Add(employee);  
        }

        public void Delete(Employee employee)
        {
            Employee e = AllocationMockStorage.Employees.FirstOrDefault(x =>x.Id == employee.Id);
            AllocationMockStorage.Employees.Remove(e);
        }

        public IList<Employee> FetchAll()
        {
            return AllocationMockStorage.Employees.OrderBy(x=> x.LastName).ToList();
        }

        public void Update(Employee updatedEmp)
        {
            Employee existingEMp = AllocationMockStorage.Employees.SingleOrDefault(x=> x.Id == updatedEmp.Id); //mi assicuro che ci sia qualcuno con id giusto

            //l'update si simula con rimozione + riaggiunta
            AllocationMockStorage.Employees.Remove(existingEMp);
            AllocationMockStorage.Employees.Add(updatedEmp);

        }
    }
}
