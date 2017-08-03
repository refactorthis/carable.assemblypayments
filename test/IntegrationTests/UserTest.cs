using System;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Exceptions;
using Xunit;

namespace IntegrationTests
{
    public class UserTest : AbstractTests
    {
        [Fact]
        public void CanCreateUser()
        {
            var repo = Get<IUserRepository>();
            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                FirstName = "Test",
                LastName = "Test",
                City = "Test",
                AddressLine1 = "Line 1",
                Country = "AUS",
                State = "state",
                Zip = "123456",
                Email = id + "@google.com"
            };

            var createdUser = repo.CreateUser(user);
        }


        [Fact(Skip = "Skipped until API method will be fixed")]
        public void DeleteUserSuccessful()
        {
            //First, create a user with known id
            var repo = Get<IUserRepository>();
            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                FirstName = "Test",
                LastName = "Test",
                City = "Test",
                AddressLine1 = "Line 1",
                Country = "AUS",
                State = "state",
                Zip = "123456",
                Email = id + "@google.com"
            };

            var createdUser = repo.CreateUser(user);

            //Then, get user
            var gotUser = repo.GetUserById(id);
            Assert.NotNull(gotUser);
            Assert.Equal(gotUser.Id, id);

            //Now, delete user
            repo.DeleteUser(id);

            //And check whether user exists now
            Assert.Throws<NotFoundException>(() => repo.GetUserById(id));
        }
    }
}
