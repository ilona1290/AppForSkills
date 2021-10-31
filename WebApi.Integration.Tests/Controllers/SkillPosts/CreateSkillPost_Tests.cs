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
                Description = "Zdjęcie rzymskiego Koloseum"
            };

            var path = "ImagesToTest/koloseum.jpg";
            var filename = "koloseum.jpg";
            var httpContent = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(path));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            // Add Skill property with file content
            httpContent.Add(fileContent, "Skill", filename);

            // Add Title property with its value
            httpContent.Add(new StringContent(skillPost.Title), "Title");

            // Add Description property with its value.
            httpContent.Add(new StringContent(skillPost.Description), "Description");

            HttpResponseMessage response = await client.PostAsync($"/api/posts", httpContent);

            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.ShouldBe(3);

        }
    }
}
