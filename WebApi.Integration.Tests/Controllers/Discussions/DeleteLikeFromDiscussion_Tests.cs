using AppForSkills.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class DeleteLikeFromDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteLikeFromDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLikeId_DeleteLikeFromDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string discussionId = "2";
            string likeId = "5";

            var response = await client.DeleteAsync($"/api/discussions/{discussionId}/likes/{likeId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
