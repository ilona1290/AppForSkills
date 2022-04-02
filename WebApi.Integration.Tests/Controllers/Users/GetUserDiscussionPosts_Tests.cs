using AppForSkills.Api;
using AppForSkills.Application.Users.Queries.GetUserDiscussionPosts;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserDiscussionPosts_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserDiscussionPosts_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserGavedPostsInDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Turysta12";

            var response = await client.GetAsync($"/api/users/{username}/discussionPosts");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<UserDiscussionPostsVm>(response);
            vm.DiscussionPosts.ShouldBeOfType<List<UserDiscussionPostDto>>();
            vm.DiscussionPosts.Count.ShouldBe(2);
        }
    }
}
