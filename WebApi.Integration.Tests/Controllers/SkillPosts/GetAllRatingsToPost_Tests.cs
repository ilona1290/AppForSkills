using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class GetAllRatingsToPost_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAllRatingsToPost_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsAllRatingsToPost()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string id = "2";

            var response = await client.GetAsync($"/api/posts/{id}/ratings");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RatingsPostVm>(response);

            vm.RatingsPost.ShouldBeOfType<List<RatingPostDto>>();
            vm.RatingsPost.Count.ShouldBe(2);
        }
    }
}
