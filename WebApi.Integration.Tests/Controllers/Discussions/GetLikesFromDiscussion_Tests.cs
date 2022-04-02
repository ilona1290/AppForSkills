using AppForSkills.Api;
using AppForSkills.Application.Likes.Queries.GetLikes;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class GetLikesFromDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetLikesFromDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsLikesFromDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string id = "2";
            var response = await client.GetAsync($"/api/discussions/{id}/likes");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<LikesVm>(response);

            vm.Likes.ShouldBeOfType<List<LikeDto>>();
            vm.Likes.Count.ShouldBe(2);
            vm.Likes[0].Username.ShouldBe("Turysta12");
        }
    }
}
