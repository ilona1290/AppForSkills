using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserSkills_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserSkills_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserSkills()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Podróżnik";

            var response = await client.GetAsync($"/api/users/{username}/skills");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<SkillPostsVm>(response);
            vm.SkillPosts.ShouldBeOfType<List<SkillPostDto>>();
            vm.SkillPosts.Count.ShouldBe(1);
        }
    }
}
