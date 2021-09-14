using AppForSkills.Api;
using AppForSkills.Application.Users.Queries.GetUserAchievements;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserAchievements_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserAchievements_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserReceivedAchievements()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Podróżnik";

            var response = await client.GetAsync($"/api/users/{username}/achievements");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<AchievementsVm>(response);
            vm.Achievements.ShouldBeOfType<List<AchievementDto>>();
            vm.Achievements.Count.ShouldBe(3);
        }
    }
}
