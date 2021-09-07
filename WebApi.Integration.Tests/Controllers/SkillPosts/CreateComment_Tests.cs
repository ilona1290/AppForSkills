using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.CreateComment;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class CreateComment_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateComment_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenComment_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var comment = new CreateCommentCommand { SkillPostId = 2, CommentText = "Ładne" };

            var response = await client.PostAsync($"/api/posts/{comment.SkillPostId}/comments",
                await Utilities.SendObjectAsContent(comment));
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(3);
        }

        [Fact]
        public async Task GivenEmptyComment_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var comment = new CreateCommentCommand { SkillPostId = 2 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PostAsync($"/api/posts/{comment.SkillPostId}/comments", await Utilities.SendObjectAsContent(comment)));

            error.Message.ShouldContain("Pole 'Comment Text' nie może być puste.");
        }

        [Fact]
        public async Task GivenCommentToNotExistSkillPost_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var comment = new CreateCommentCommand { SkillPostId = 80, CommentText = "Super" };

            var error = Should.Throw<WrongIDException>(async () => await client
                .PostAsync($"/api/posts/{comment.SkillPostId}/comments", await Utilities.SendObjectAsContent(comment)));

            error.Message.ShouldBe("SkillPost not exists. Wrong Id");
        }
    }
}
