using AppForSkills.Application.Discussions.Commands.DeleteDiscussion;
using AppForSkills.Application.Exceptions;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Discussion.Commands.DeleteDiscussion
{
    public class DeleteDiscussionCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteDiscussionCommandHandler _handler;

        public DeleteDiscussionCommandHandlerTests() : base()
        {
            _handler = new DeleteDiscussionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteDiscussion()
        {
            var command = new DeleteDiscussionCommand() { Id = 3 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var discussion = await _context.Discussions.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            discussion.StatusId.CompareTo(0);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntDeleteDiscussion()
        {
            var command = new DeleteDiscussionCommand() { Id = 0 };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Discussion with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
