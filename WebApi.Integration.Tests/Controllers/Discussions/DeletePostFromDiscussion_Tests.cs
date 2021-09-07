using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class DeletePostFromDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeletePostFromDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenPostId_DeletePost()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "3";
            var response = await client.DeleteAsync($"/api/discussions/2/posts/{id}");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenWrongPostId_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string id = "0";

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .DeleteAsync($"/api/discussions/3/posts/{id}"));

            error.Message.ShouldContain("Wartość pola 'Post Id' musi być większa niż '0'.");
        }
    }
}
