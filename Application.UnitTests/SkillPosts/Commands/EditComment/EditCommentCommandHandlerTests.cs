using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.EditComment;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.EditComment
{
    public class EditCommentCommandHandlerTests : CommandTestBase
    {
        private readonly EditCommentCommandHandler _handler;

        public EditCommentCommandHandlerTests() : base()
        {
            _handler = new EditCommentCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditComment()
        {
            var command = new EditCommentCommand()
            {
                Id = 2,
                CommentText = "Dziękuję :)"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var comment = await _context.Comments.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            comment.ModifiedBy.ShouldBe("user");
            comment.CommentText.ShouldBe(command.CommentText);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntEditComment()
        {
            var command = new EditCommentCommand()
            {
                Id = 0,
                CommentText = "Dziękuję :)"
            };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Comment with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
        }
    }
}
