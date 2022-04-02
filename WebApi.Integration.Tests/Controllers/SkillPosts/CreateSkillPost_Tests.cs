using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Commands.CreateSkillPost;
using Shouldly;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.SkillPosts
{
    public class CreateSkillPost_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateSkillPost_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenSkillPost_ReturnsId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
           
            var skillPost = new CreateSkillPostCommand()
            {
                Title = "Koloseum",
                Description = "Zdjęcie rzymskiego Koloseum",
                Skill = "https://app.blob.core.windows.net/upload-container/picture.jpg"
            };


            HttpResponseMessage response = await client.PostAsync($"/api/posts", await Utilities.SendObjectAsContent(skillPost));

            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(2);

        }
    }
}
