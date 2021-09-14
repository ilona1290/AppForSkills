using AppForSkills.Application.SkillPosts.Commands.CreateComment;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly CreateCommentCommandHandler _handler;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new CreateCommentCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertCommentToSkillPost()
        {
            var command = new CreateCommentCommand()
            {
                CommentText = "Super!",
                SkillPostId = 2
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var comment = await _context.Comments.FirstAsync(x => x.Id == result, CancellationToken.None);

            comment.ShouldNotBeNull();
            comment.Id.ShouldBe(result);
            comment.CommentText.ShouldBe(command.CommentText);
            comment.ParentCommentId.ShouldBeNull();
        }
    }
}
