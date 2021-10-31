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
            var mockFileStore = new Mock<IFileStore>();
            var fileStore = mockFileStore.Object;

            var mockFile = new Mock<IFormFile>();
            mockFile.Setup(m => m.FileName).Returns("Wieza_Eiffla_2.jpg");
            var skill = mockFile.Object;

            var extensionMock = new Mock<IPath>();
            extensionMock.Setup(s => s.GetExtension(skill.FileName)).Returns(".jpg");

            byte[] newImage = File.ReadAllBytes("ImagesToTest\\Wieza_Eiffla_2.jpg");
            mockFileStore.Setup(s => s.FormFileToBytesArray(skill)).Returns(newImage);

            var command = new EditSkillPostCommand()
            {
                Id = 2,
                Title = "Zdjęcie Wieży Eiffla",
                Description = "Przesyłam wykonane przeze mnie zdjęcie Wieży Eiffla",
                Skill = skill
            };

            mockFileStore.Setup(s => s.SafeWriteFile(newImage, skill.FileName, "Images")).Returns("Images");

            var _handler = new EditSkillPostCommandHandler(_context, fileStore);

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == command.Id, CancellationToken.None);
            skillPost.ShouldNotBeNull();
            skillPost.AddressOfPhotoOrVideo.ShouldBe("Images\\Wieza_Eiffla_2.jpg");
        }
    }
}
