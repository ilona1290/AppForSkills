using AppForSkills.Api;
using AppForSkills.Application.Discussions.GetDiscussions;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class GetAllDiscussions_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAllDiscussions_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsAllDiscussions()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/discussions");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DiscussionsVm>(response);

            vm.Discussions.ShouldBeOfType<List<DiscussionDto>>();
            vm.Discussions.Count.ShouldBe(3);
        }
    }
}
