using AppForSkills.Api;
using AppForSkills.Application.Users.Queries.GetUserInformation;
using Shouldly;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class GetAllInformation_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAllInformation_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsAllInformationAboutUser()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            string username = "Turysta12";

            var response = await client.GetAsync($"/api/users/{username}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<UserInformationVm>(response);
            vm.UserSkills.ShouldBe(0);
            vm.UserComments.ShouldBe(1);
            vm.GavedRatings.ShouldBe(1);
            vm.Achievements.ShouldBe(1);
            vm.Discussions.ShouldBe(1);
        }
    }
}
