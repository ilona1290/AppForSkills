using AppForSkills.Api;
using AppForSkills.Application.Discussions.Commands.EditPost;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class EditPostToDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EditPostToDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenPostToDiscussion_UpdatePost()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var post = new EditPostCommand
            {
                Id = 7,
                PostText = "Koszykówkę"
            };

            var response = await client.PutAsync($"/api/discussions/3/posts/{post.Id}",
                await Utilities.SendObjectAsContent(post));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenEmptyPost_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var post = new EditPostCommand { Id = 7 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PutAsync($"/api/discussions/3/posts/{post.Id}", await Utilities.SendObjectAsContent(post)));

            error.Message.ShouldContain("Pole 'Post Text' nie może być puste.");
        }
    }
}
