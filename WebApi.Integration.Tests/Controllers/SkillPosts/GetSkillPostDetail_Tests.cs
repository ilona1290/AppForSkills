using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class GetSkillPostDetail_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetSkillPostDetail_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenSkillPostId_ReturnsSkillPostDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.GetAsync($"/api/posts/{id}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<SkillPostVm>(response);
            vm.ShouldNotBeNull();
            vm.AddressOfPhotoOrVideo.ShouldBe("images/Eiffel_Tower.jpg");
        }

        [Fact]
        public async Task GivenWrongSkillPostId_ReturnsException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "8";
            var error = Should.Throw<WrongIDException>(async () => await client.GetAsync($"/api/posts/{id}"));

            error.Message.ShouldBe("Skill Post with gaved id could not display, because not exists in database. " +
                    "Give another id.");
        }
    }
}
