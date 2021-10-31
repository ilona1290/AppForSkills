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
            var username = "Podróżnik";
            var skillPost = new EditSkillPostCommand()
            {
                Id = 2,
                Title = "Wieża Eiffla",
                Description = "Zdjęcie Wieży Eiffla"
            };

            var path = "ImagesToTest/Wieza_Eiffla_2.jpg";
            var filename = "Wieza_Eiffla_2.jpg";
            var httpContent = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(path));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            // Add Skill property with file content
            httpContent.Add(fileContent, "Skill", filename);

            // Add Title property with its value
            httpContent.Add(new StringContent(skillPost.Title), "Title");

            // Add Description property with its value.
            httpContent.Add(new StringContent(skillPost.Description), "Description");

            // Add Id property with its value.
            httpContent.Add(new StringContent(skillPost.Id.ToString()), "Id");

            HttpResponseMessage response = await client.PutAsync($"/api/users/{username}/skills/{skillPost.Id}", httpContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
