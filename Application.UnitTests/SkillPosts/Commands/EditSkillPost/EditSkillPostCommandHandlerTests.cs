using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.SkillPosts.Commands.EditSkillPost;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System.IO;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.EditSkillPost
{
    public class EditSkillPostCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        public EditSkillPostCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditWithChangingImageSkillPost()
        {
            var command = new EditSkillPostCommand()
            {
                Id = 1,
                Title = "Zdjęcie Wieży Eiffla",
                Description = "Przesyłam wykonane przeze mnie zdjęcie Wieży Eiffla",
                Skill = "https://app.blob.core.windows.net/upload-container/picture.jpg"
            };

            var _handler = new EditSkillPostCommandHandler(_context);

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == command.Id, CancellationToken.None);
            skillPost.ShouldNotBeNull();
            skillPost.AddressOfPhotoOrVideo.ShouldBe("https://app.blob.core.windows.net/upload-container/picture.jpg");
        }
    }
}
