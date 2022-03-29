using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class DeleteSkillPost_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteSkillPost_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenSkillPostId_DeleteSkillPost()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string skillPostId = "2";
            var response = await client.DeleteAsync($"api/posts/{skillPostId}");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenWrongSkillPostId_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "100";

            var error = Should.Throw<WrongIDException>(async () => await client
                .DeleteAsync($"api/posts/{skillPostId}"));

            error.Message.ShouldBe("Skill Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
