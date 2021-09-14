using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using AppForSkills.Application.Users.Commands.UpdateLoginDate;
using AppForSkills.Application.Users.Queries.GetUserInformation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class UpdateLoginDate_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateLoginDate_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLoggedInUser_UpdateRecentLoginDate()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var user = new UpdateLoginDateCommand
            {
                Username = "alice",
                RecentLogin = DateTime.Now
            };

            var response = await client.PutAsync($"/api/users/update-login",
                await Utilities.SendObjectAsContent(user));
            response.EnsureSuccessStatusCode();

            var responseAfterUpdate = await client.GetAsync($"/api/users/{user.Username}");
            responseAfterUpdate.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<UserInformationVm>(responseAfterUpdate);
            vm.RecentLoginDate.ShouldBe(user.RecentLogin);
        }

        [Fact]
        public async Task GivenNotExistUser_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var user = new UpdateLoginDateCommand
            {
                Username = "alice11",
                RecentLogin = DateTime.Now
            };

            var error = Should.Throw<WrongIDException>(async () => await client
                .PutAsync($"/api/users/update-login", await Utilities.SendObjectAsContent(user)));

            error.Message.ShouldBe("User not exists in database.");
        }
    }
}
