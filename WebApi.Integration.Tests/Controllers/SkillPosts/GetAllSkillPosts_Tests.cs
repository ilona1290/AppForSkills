using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class GetAllSkillPosts_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAllSkillPosts_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsAllSkillPosts()
        {
            var client = await _factory.GetAuthenticatedClientAsync();


            var response = await client.GetAsync($"/api/posts");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<SkillPostsVm>(response);

            vm.SkillPosts.ShouldBeOfType<List<SkillPostDto>>();
            vm.SkillPosts.Count.ShouldBe(1);
        }
    }
}
