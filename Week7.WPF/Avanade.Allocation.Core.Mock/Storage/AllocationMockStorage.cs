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

        public static void Initialize()
        {
            //creazione della lista vuota
            Users = new List<User>();

            //aggiunta utenti di default
            Users.Add(new User() { Id = 1, UserName = "mario.rossi", Password = "12345", Email = "mario@gmail.com" });
            Users.Add(new User() { Id = 2, UserName = "giuseppe.verdi", Password = "abcde", Email = "giuseppe@gmail.com" });

        }
    }
}
