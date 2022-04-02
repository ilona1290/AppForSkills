using AppForSkills.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class DeleteLikeFromPostInDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteLikeFromPostInDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLikeId_DeleteLikeFromPostInDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string discussionId = "1";
            string likeId = "4";

            var response = await client.DeleteAsync($"/api/discussions/{discussionId}/posts/likes/{likeId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
