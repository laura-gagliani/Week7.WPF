using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using Xunit;

namespace Avanade.Allocation.WPF.Test
{
    public class AuthenticationTest
    {
        [Fact]
        public void ShouldSignInWithCorrectCredentials()
        {
            //arrange
            //recupero dati necessari, creo il repo, creo il bl, istanzio i valori di input
            AllocationMockStorage.Initialize();
            IUserRepository userRepository = new MockUserRepository();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(userRepository);

            var userName = "mario.rossi";
            var password = "12345";

            //act
            //nel test non ci interessa molto usare async
            var result = layer.SignIn(userName, password);

            //assert
            Assert.True(result.Success);

        }

        [Fact]
        public void ShouldNotSignInWithWrongCredentials()
        {
            //arrange
            //recupero dati necessari, creo il repo, creo il bl, istanzio i valori di input
            AllocationMockStorage.Initialize();
            IUserRepository userRepository = new MockUserRepository();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(userRepository);

            var userName = "mario.rossi";
            var password = "abc";

            //act
            //nel test non ci interessa molto usare async
            var result = layer.SignIn(userName, password);

            //assert
            Assert.True(!result.Success);

        }
    }
}
