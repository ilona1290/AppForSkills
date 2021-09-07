using AppForSkills.Api;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class GetDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDiscussionId_ReturnsDiscussionDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.GetAsync($"/api/discussions/{id}/posts");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DiscussionVm>(response);
            vm.ShouldNotBeNull();
            vm.FirstPost.ShouldBe("Jaki kraj chcielibyście odwiedzić?");
        }

        [Fact]
        public async Task GivenWrongDiscussionId_ReturnsException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "8";
            var error = Should.Throw<WrongIDException>(async () => await client.GetAsync($"/api/discussions/{id}/posts"));

            error.Message.ShouldBe("Discussion with gaved id could not display, because not exists in database. " +
                    "Give another id.");
        }
    }
}
