using AppForSkills.Api;
using AppForSkills.Application.Discussions.Commands.CreatePost;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class CreatePostToDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreatePostToDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenPostToDiscussion_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var post = new CreatePostCommand { DiscussionId = 2, PostText = "Siatkówkę" };

            var response = await client.PostAsync($"/api/discussions/{post.DiscussionId}/posts",
                await Utilities.SendObjectAsContent(post));
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(5);
        }

        [Fact]
        public async Task GivenEmptyPostDiscussion_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var post = new CreatePostCommand { DiscussionId = 3, PostText = "" };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PostAsync($"/api/discussions/{post.DiscussionId}/posts", await Utilities.SendObjectAsContent(post)));

            error.Message.ShouldContain("Pole 'Post Text' nie może być puste.");
        }

        [Fact]
        public async Task GivenPostToNotExistDiscussion_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var post = new CreatePostCommand { DiscussionId = 8, PostText = "Piłkę ręczną" };

            var error = Should.Throw<WrongIDException>(async () => await client
                .PostAsync($"/api/discussions/{post.DiscussionId}/posts", await Utilities.SendObjectAsContent(post)));

            error.Message.ShouldBe("Discussion not exists. Wrong Id");
        }
    }
}
