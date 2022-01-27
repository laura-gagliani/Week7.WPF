using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Storage
{
    public static class AllocationMockStorage
    {
        public static List<User> Users { get; set; }
        public static List<Employee> Employees { get; set; }



        public static void Initialize()
        {
            //creazione della lista vuota
            Users = new List<User>();

            //aggiunta utenti di default
            Users.Add(new User() { Id = 1, UserName = "mario.rossi", Password = "12345", Email = "mario@gmail.com" });
            Users.Add(new User() { Id = 2, UserName = "giuseppe.verdi", Password = "abcde", Email = "giuseppe@gmail.com" });


            Employees = new List<Employee>();

            Employees.Add(new Employee() { Id = 1, FirstName = "Mario", LastName = "Rossi", DateOfBirth = new DateTime(1975,12,12), 
                                            Email="mario@gmail.com", Salary = 8000, IsEnabled = true });
            Employees.Add(new Employee() { Id = 2, FirstName = "Maria", LastName = "Bianchi", DateOfBirth = new DateTime(1982,12,12), 
                                            Email="maria@gmail.com", Salary = 8000, IsEnabled = true });

        }
    }
}
