using AppForSkills.Api;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserSelectedDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserSelectedDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserSelectedDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Podróżnik";
            string id = "2";
            var response = await client.GetAsync($"/api/users/{username}/discussions/{id}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DiscussionVm>(response);
            vm.ShouldNotBeNull();
            vm.FirstPost.ShouldBe("Jaki kraj chcielibyście odwiedzić?");
        }
    }
}
