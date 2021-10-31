using AppForSkills.Api;
using AppForSkills.Application.Users.Queries.GetUserRatings;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetUserRatings_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetUserRatings_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUserGavedRatings()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Turysta12";

            var response = await client.GetAsync($"/api/users/{username}/ratings");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RatingsVm>(response);
            vm.Ratings.ShouldBeOfType<List<RatingDto>>();
            vm.Ratings.Count.ShouldBe(1);
            vm.Ratings[0].Value.ShouldBe(5);
        }
    }
}
