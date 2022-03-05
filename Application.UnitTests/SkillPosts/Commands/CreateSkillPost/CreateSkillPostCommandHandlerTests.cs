using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.SkillPosts.Commands.CreateSkillPost;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly IMapper _mapper;
        public CreateSkillPostCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertSkillPost()
        {
            /*var mockFileStore = new Mock<IFileStore>();
            var fileStore = mockFileStore.Object;

            var mockFile = new Mock<IFormFile>();
            mockFile.Setup(m => m.FileName).Returns("Koloseum.jpg");
            var skill = mockFile.Object;

            var extensionMock = new Mock<IPath>();
            extensionMock.Setup(s => s.GetExtension(skill.FileName)).Returns(".jpg");

            byte[] expectedRead = new byte[] { (byte)129, (byte)130, (byte)131 };
            mockFileStore.Setup(s => s.FormFileToBytesArray(skill)).Returns(expectedRead);

            var command = new CreateSkillPostCommand()
            {
                Title = "Zdjęcie Koloseum",
                Description = "Przesyłam wykonane przeze mnie zdjęcie Koloseum",
                Skill = skill
            };

            mockFileStore.Setup(s => s.SafeWriteFile(expectedRead, skill.FileName, "Images")).Returns("Images");

            var _handler = new CreateSkillPostCommandHandler(_context, _mapper, fileStore);

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == result, CancellationToken.None);
            skillPost.ShouldNotBeNull();
            skillPost.Id.ShouldBe(result);
            skillPost.AddressOfPhotoOrVideo.ShouldBe("Images\\Koloseum.jpg");*/
        }
    }
}
