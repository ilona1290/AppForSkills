using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Discussions
{
    public class DeleteDiscussion_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteDiscussion_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDiscussionId_DeleteDiscussion()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.DeleteAsync($"/api/discussions/{id}");
            response.EnsureSuccessStatusCode();

            var error = Should.Throw<WrongIDException>(async () => await client
                .GetAsync($"/api/discussions/{id}"));

            error.Message.ShouldBe("Discussion with gaved id could not display, because not exists in database. " +
                    "Give another id.");
        }

        [Fact]
        public async Task GivenWrongDiscussionId_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string id = "0";

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .DeleteAsync($"/api/discussions/{id}"));

            error.Message.ShouldContain("Wartość pola 'Id' musi być większa niż '0'.");
        }
    }
}
