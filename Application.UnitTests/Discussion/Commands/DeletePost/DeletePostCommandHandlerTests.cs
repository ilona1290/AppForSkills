using AppForSkills.Application.Discussions.Commands.DeletePost;
using AppForSkills.Application.Exceptions;
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

namespace Application.UnitTests.Discussion.Commands.DeletePost
{
    public class DeletePostCommandHandlerTests : CommandTestBase
    {
        private readonly DeletePostCommandHandler _handler;

        public DeletePostCommandHandlerTests() : base()
        {
            _handler = new DeletePostCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeletePost()
        {
            var command = new DeletePostCommand() { PostId = 3 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var post = await _context.PostsInDiscussion.FirstAsync(x => x.Id == command.PostId, CancellationToken.None);

            post.StatusId.CompareTo(0);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntDeletePost()
        {
            var command = new DeletePostCommand { PostId = 0 };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
