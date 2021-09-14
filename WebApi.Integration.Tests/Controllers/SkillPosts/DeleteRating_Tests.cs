using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class DeleteRating_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteRating_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenRatingId_DeleteRating()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string skillPostId = "2";
            string idRating = "2";
            var response = await client.DeleteAsync($"/api/posts/{skillPostId}/ratings/{idRating}");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenWrongRatingId_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            string idRating = "100";

            var error = Should.Throw<WrongIDException>(async () => await client
                .DeleteAsync($"/api/posts/{skillPostId}/ratings/{idRating}"));

            error.Message.ShouldBe("Rating with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
