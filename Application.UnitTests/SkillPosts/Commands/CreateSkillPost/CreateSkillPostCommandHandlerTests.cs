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

            var command = new CreateSkillPostCommand()
            {
                Title = "Zdjęcie Koloseum",
                Description = "Przesyłam wykonane przeze mnie zdjęcie Koloseum",
                Skill = "https://app.blob.core.windows.net/upload-container/picture.jpg"
            };

            var _handler = new CreateSkillPostCommandHandler(_context, _mapper);

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == result, CancellationToken.None);
            skillPost.ShouldNotBeNull();
            skillPost.Id.ShouldBe(result);
            skillPost.AddressOfPhotoOrVideo.ShouldBe("https://app.blob.core.windows.net/upload-container/picture.jpg");
        }
    }
}
