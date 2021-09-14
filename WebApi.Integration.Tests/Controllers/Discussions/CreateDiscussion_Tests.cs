using AppForSkills.Api;
using AppForSkills.Application.Discussions.Commands.CreateDiscussion;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class CreateDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDiscussion_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussion = new CreateDiscussionCommand { FirstPost = "Co tam?" };

            var response = await client.PostAsync($"/api/discussions", await Utilities.SendObjectAsContent(discussion));
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(4);
        }

        [Fact]
        public async Task GivenEmptyDiscussion_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussion = new CreateDiscussionCommand { FirstPost = "" };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PostAsync($"/api/discussions", await Utilities.SendObjectAsContent(discussion)));

            error.Message.ShouldContain("Pole 'First Post' nie może być puste.");
        }
    }
}
