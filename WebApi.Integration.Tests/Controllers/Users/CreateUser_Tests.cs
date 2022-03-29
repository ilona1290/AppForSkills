using AppForSkills.Api;
using AppForSkills.Application.Users.Commands.CreateUser;
using AppForSkills.Application.Users.Queries.GetUserInformation;
using Shouldly;
using System;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class CreateUser_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateUser_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenBussinessUser_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var user = new CreateUserCommand
            {
                Username = "user123",
                RecentLoginDate = DateTime.Now.ToString(),
                RegistrationDate = DateTime.Now.ToString()
            };

            var response = await client.PostAsync($"/api/users/create-user", await Utilities.SendObjectAsContent(user));
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(6);

            var responseAfterUpdate = await client.GetAsync($"/api/users/{user.Username}");
            responseAfterUpdate.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<UserInformationVm>(responseAfterUpdate);
            vm.Username.ShouldBe(user.Username);
        }
    }
}
