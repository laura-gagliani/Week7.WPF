using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.BusinessLayer
{
    public class MainBusinessLayer 
    {

        private IEmployeeRepository _EmployeeRepository;

        public MainBusinessLayer(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        

        //qui vogliamo restituire la lista dei dipendenti
        public IList<Employee> FetchAllEmployees()
        {
            return _EmployeeRepository.FetchAll();
        }

        public Response CreateEmployee(Employee e)
        {
            if (e != null)
                return new Response { Success = false, Message = "Invalid entity" };
            if (e.Salary < 0.0)
                return new Response { Success = false, Message = "Salary must be positive" };

            _EmployeeRepository.Create(e);
            return new Response { Success = true, Message = $"Employee {e.FirstName} {e.LastName} successfully created" };

        }

        public Response DeleteEmployee(Employee e)
        {
            if (e == null)
                return new Response { Success = false, Message = "Invalid entity" };
            if (e.Id < 0)
                return new Response { Success = false, Message = $"Id {e.Id} is invalid" };

            Employee empToDelete =_EmployeeRepository.FetchAll().Where(x => x.Id.Equals(e.Id)).SingleOrDefault();
            if (empToDelete == null)
                return new Response { Success = false, Message = $"No employee with Id = {e.Id} was found" };

            _EmployeeRepository.Delete(empToDelete);
            return new Response() { Success = true, Message = $"Employee {empToDelete.FirstName} {empToDelete.LastName} successfully created" };
        }

        public Response UpdateEmployee(Employee e)
        {
            //TODO: implementa update
            throw new NotImplementedException();
        }
    }
}
