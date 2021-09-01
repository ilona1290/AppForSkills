using AppForSkills.Api;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class GetDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDiscussionId_ReturnsDiscussionDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.GetAsync($"/api/discussions/{id}/posts");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DiscussionVm>(response);
            vm.ShouldNotBeNull();
            vm.FirstPost.ShouldBe("Jaki kraj chcielibyście odwiedzić?");
        }
    }
}
