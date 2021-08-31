using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.DeleteComment;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.DeleteComment
{
    public class DeleteCommentCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteCommentCommandHandler _handler;

        public DeleteCommentCommandHandlerTests() : base()
        {
            _handler = new DeleteCommentCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteComment()
        {
            var command = new DeleteCommentCommand() { CommentId = 2 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var comment = await _context.Comments.FirstAsync(x => x.Id == command.CommentId, CancellationToken.None);

            comment.StatusId.ShouldBe(0);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntDeleteComment()
        {
            var command = new DeleteCommentCommand() { CommentId = 0 };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Comment with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
