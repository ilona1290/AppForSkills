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
    public class GetLikesFromPostInDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetLikesFromPostInDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsLikesFromPostInDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string id = "2";
            string idPost = "3";
            var response = await client.GetAsync($"/api/discussions/{id}/posts/{idPost}/likes");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<LikesVm>(response);

            vm.Likes.ShouldBeOfType<List<LikeDto>>();
            vm.Likes.Count.ShouldBe(1);
            vm.Likes[0].Username.ShouldBe("Podróżnik");
        }
    }
}
