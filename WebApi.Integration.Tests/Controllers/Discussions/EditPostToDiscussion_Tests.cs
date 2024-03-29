﻿using AppForSkills.Api;
using AppForSkills.Application.Discussions.Commands.EditPost;
using Shouldly;
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
        public async Task GivenPostToDiscussion_Update()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussionId = "1";
            var post = new EditPostCommand
            {
                Id = 4,
                PostText = "Brazylię"
            };

            var response = await client.PutAsync($"/api/discussions/{discussionId}/posts/{post.Id}",
                await Utilities.SendObjectAsContent(post));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenEmptyPost_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussionId = "3";
            var post = new EditPostCommand { Id = 7 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PutAsync($"/api/discussions/{discussionId}/posts/{post.Id}", await Utilities.SendObjectAsContent(post)));

            error.Message.ShouldContain("Pole 'Post Text' nie może być puste.");
        }
    }
}
