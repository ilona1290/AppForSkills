using AppForSkills.Api;
using AppForSkills.Application.Discussions.GetDiscussions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserDiscussions_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserDiscussions_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserDiscussions()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Podróżnik";

            var response = await client.GetAsync($"/api/users/{username}/discussions");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DiscussionsVm>(response);
            vm.Discussions.ShouldBeOfType<List<DiscussionDto>>();
            vm.Discussions.Count.ShouldBe(2);
        }
    }
}
