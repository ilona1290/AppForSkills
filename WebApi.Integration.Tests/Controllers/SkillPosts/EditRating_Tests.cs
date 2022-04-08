using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Commands.EditRating;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class EditRating_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EditRating_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenRating_Update()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "1";
            var rating = new EditRatingCommand
            {
                Id = 1,
                Value = 3
            };

            var response = await client.PutAsync($"/api/posts/{skillPostId}/ratings/{rating.Id}",
                await Utilities.SendObjectAsContent(rating));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenEmptyRating_ValidationFieldsFail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string skillPostId = "2";
            var rating = new EditRatingCommand { Id = 2 };

            var error = Should.Throw<FluentValidation.ValidationException>(async () => await client
                .PutAsync($"/api/posts/{skillPostId}/ratings/{rating.Id}", await Utilities.SendObjectAsContent(rating)));

            error.Message.ShouldContain("Wartość pola 'Value' musi być większa niż '0'.");
        }
    }
}
