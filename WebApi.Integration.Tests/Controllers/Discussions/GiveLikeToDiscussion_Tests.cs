using AppForSkills.Api;
using AppForSkills.Application.Likes.Commands.GiveLike;
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
    public class GiveLikeToDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GiveLikeToDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLikeToDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var like = new GiveLikeCommand { DiscussionId = 2, User = "user12" };
            string id = "2";

            var response = await client.PostAsync($"/api/discussions/{id}/likes",
                await Utilities.SendObjectAsContent(like));
            response.EnsureSuccessStatusCode();

            var responseAfterUpdate = await client.GetAsync($"/api/discussions/{id}/likes");
            responseAfterUpdate.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<LikesVm>(responseAfterUpdate);
            var last = vm.Likes.Last();
            last.Username.ShouldBe(like.User);
        }
    }
}
