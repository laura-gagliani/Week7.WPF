using Avanade.Allocation.Core.Utils;
using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avanade.Allocation.Core.Repositories;

namespace Avanade.Allocation.Core.BusinessLayer
{
    public class AuthenticationBusinessLayer
    {
        private IUserRepository _userRepository;

        public AuthenticationBusinessLayer(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response SignIn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                return new Response() { Success = false, Message = "Invalid username" };
            if (string.IsNullOrEmpty(password))
                return new Response() { Success = false, Message = "Incorrect password" };

            User existingUser = GetUserByUsername(userName);

            if (existingUser == null)
                return new Response() { Success = false, Message = "This username does not exist!" };

            if (!existingUser.Password.Equals(password))
                return new Response() { Success = false, Message = "Incorrect password!" };

            return new Response() { Success = true, Message = "User authenticated" };


        }
        public async Task<Response> SignInAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            var response = SignIn(userName, password);

            //simuliamo un ritardo di 5 sec
            //await Task.Delay(5000);

            return response;
        }

        private User GetUserByUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;
            return _userRepository.GetByUserName(userName); 
        }
    }
}
