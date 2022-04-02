using AppForSkills.Api;
using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.CreateRating;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class CreateRating_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateRating_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenRating_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var rating = new CreateRatingCommand { SkillPostId = 2, Value = 4 };

            var response = await client.PostAsync($"/api/posts/{rating.SkillPostId}",
                await Utilities.SendObjectAsContent(rating));
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(3);
        }

        [Fact]
        public async Task GivenWrongRating_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var rating = new CreateRatingCommand { SkillPostId = 2, Value = 7 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PostAsync($"/api/posts/{rating.SkillPostId}", await Utilities.SendObjectAsContent(rating)));

            error.Message.ShouldContain("Wartość pola 'Value' musi być równa lub mniejsza niż '5'.");
        }

        [Fact]
        public async Task GivenRatingToNotExistSkillPost_ReturnsWrongIDException()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var rating = new CreateRatingCommand { SkillPostId = 80, Value = 5 };

            var error = Should.Throw<WrongIDException>(async () => await client
                .PostAsync($"/api/posts/{rating.SkillPostId}", await Utilities.SendObjectAsContent(rating)));

            error.Message.ShouldBe("SkillPost not exists. Wrong Id");
        }
    }
}
