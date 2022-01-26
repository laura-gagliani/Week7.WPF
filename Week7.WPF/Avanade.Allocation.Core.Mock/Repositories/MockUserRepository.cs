﻿using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        public User GetByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            return AllocationMockStorage.Users.Where(x => x.UserName.Equals(userName)).SingleOrDefault();
        }
    }
}
