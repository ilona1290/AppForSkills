using AppForSkills.Api;
using AppForSkills.Application.SkillPosts.Commands.EditSkillPost;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApi.Integration.Tests.Common;
using Xunit;

namespace WebApi.Integration.Tests.Controllers.Users
{
    public class EditSkillPost_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public EditSkillPost_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenSkillPostWithDiffrentImage_Update()
        {
            var client = await _factory.GetAuthenticatedClientAsync();
            var skillPost = new EditSkillPostCommand()
            {
                Id = 2,
                Title = "Wieża Eiffla",
                Description = "Zdjęcie Wieży Eiffla",
                Skill = "https://app.blob.core.windows.net/upload-container/picture1.jpg"
            };

            HttpResponseMessage response = await client.PutAsync($"/api/posts/{skillPost.Id}", await Utilities.SendObjectAsContent(skillPost));

            response.EnsureSuccessStatusCode();
        }
    }
}
