using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Commands.EditComment;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class EditComment_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EditComment_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenComment_Update()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            var comment = new EditCommentCommand
            {
                Id = 2,
                CommentText = "Ładnie wyszło"
            };

            var response = await client.PutAsync($"/api/posts/{skillPostId}/comments/{comment.Id}",
                await Utilities.SendObjectAsContent(comment));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenEmptyComment_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            var comment = new EditCommentCommand { Id = 2 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PutAsync($"/api/posts/{skillPostId}/comments/{comment.Id}", await Utilities.SendObjectAsContent(comment)));

            error.Message.ShouldContain("Pole 'Comment Text' nie może być puste.");
        }
    }
}
