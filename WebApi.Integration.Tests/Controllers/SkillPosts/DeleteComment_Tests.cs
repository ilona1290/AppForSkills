using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class DeleteComment_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteComment_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCommentId_DeleteRating()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string skillPostId = "2";
            string idComment = "2";
            var response = await client.DeleteAsync($"/api/posts/{skillPostId}/comments/{idComment}");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenWrongCommentId_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            string idComment = "100";

            var error = Should.Throw<WrongIDException>(async () => await client
                .DeleteAsync($"/api/posts/{skillPostId}/comments/{idComment}"));

            error.Message.ShouldBe("Comment with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
