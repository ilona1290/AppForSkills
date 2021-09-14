using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.SkillPosts.Commands.EditSkillPost;
using AppForSkills.Domain.Entities;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
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
            mockFile.Setup(m => m.FileName).Returns("Koloseum2.jpg");
            var skill = mockFile.Object;

            var extensionMock = new Mock<IPath>();
            extensionMock.Setup(s => s.GetExtension(skill.FileName)).Returns(".jpg");

            byte[] expectedRead = new byte[] { (byte)149, (byte)230, (byte)231 };
            mockFileStore.Setup(s => s.FormFileToBytesArray(skill)).Returns(expectedRead);

            var command = new EditSkillPostCommand()
            {
                Id = 2,
                Title = "Zdjęcie Koloseum",
                Description = "Przesyłam wykonane przeze mnie zdjęcie Koloseum",
                Skill = skill
            };

            mockFileStore.Setup(s => s.SafeWriteFile(expectedRead, skill.FileName, "Images")).Returns("Images");

            var _handler = new EditSkillPostCommandHandler(_context, fileStore);

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == command.Id, CancellationToken.None);
            skillPost.ShouldNotBeNull();
            skillPost.AddressOfPhotoOrVideo.ShouldBe("Images/Koloseum2.jpg");
        }
    }
}
