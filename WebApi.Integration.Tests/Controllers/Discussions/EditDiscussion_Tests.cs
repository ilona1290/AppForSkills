using AppForSkills.Api;
using AppForSkills.Application.Discussions.Commands.EditDiscussion;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class EditDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EditDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDiscussion_Update()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussion = new EditDiscussionCommand
            {
                DiscussionId = 3,
                FirstPost = "Jakie sporty uprawiacie? " +
                "Macie jakieś sukcesy?"
            };

            var response = await client.PutAsync($"/api/discussions/{discussion.DiscussionId}",
                await Utilities.SendObjectAsContent(discussion));
            response.EnsureSuccessStatusCode();

            var responseAfterUpdate = await client.GetAsync($"/api/discussions/{discussion.DiscussionId}");
            responseAfterUpdate.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<DiscussionVm>(responseAfterUpdate);
            vm.FirstPost.ShouldBe(discussion.FirstPost);
        }

        [Fact]
        public async Task GivenEmptyDiscussion_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var discussion = new EditDiscussionCommand { };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PutAsync($"/api/discussions/{discussion.DiscussionId}", await Utilities.SendObjectAsContent(discussion)));

            error.Message.ShouldContain("Wartość pola 'Discussion Id' musi być większa niż '0'.");
            error.Message.ShouldContain("Pole 'First Post' nie może być puste.");
        }
    }
}
