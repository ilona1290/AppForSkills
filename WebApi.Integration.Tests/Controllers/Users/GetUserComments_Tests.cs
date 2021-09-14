using AppForSkills.Api;
using AppForSkills.Application.Users.Queries.GetUserComments;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserComments_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserComments_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserGavedComments()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Turysta12";

            var response = await client.GetAsync($"/api/users/{username}/comments");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CommentsVm>(response);
            vm.Comments.ShouldBeOfType<List<UserCommentDto>>();
            vm.Comments.Count.ShouldBe(1);
        }
    }
}
