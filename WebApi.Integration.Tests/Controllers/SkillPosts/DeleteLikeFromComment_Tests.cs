using AppForSkills.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class DeleteLikeFromComment_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteLikeFromComment_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLikeId_DeleteLikeFromComment()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            string likeId = "1";

            var response = await client.DeleteAsync($"/api/posts/{skillPostId}/comments/likes/{likeId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
