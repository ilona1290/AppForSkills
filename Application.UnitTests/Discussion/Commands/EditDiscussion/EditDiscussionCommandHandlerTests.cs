using AppForSkills.Application.Discussions.Commands.EditDiscussion;
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

namespace Application.UnitTests.Discussion.Commands.EditDiscussion
{
    public class EditDiscussionCommandHandlerTests : CommandTestBase
    {
        private readonly EditDiscussionCommandHandler _handler;

        public EditDiscussionCommandHandlerTests() : base()
        {
            _handler = new EditDiscussionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditDiscussion()
        {
            var command = new EditDiscussionCommand() 
            { 
                DiscussionId = 3, 
                FirstPost = "Macie jakieś hobby? Jak tak to jakie?" 
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var discussion = await _context.Discussions.FirstAsync(x => x.Id == command.DiscussionId, CancellationToken.None);

            discussion.ModifiedBy.ShouldBe("user");
            discussion.FirstPost.ShouldBe(command.FirstPost);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntEditDiscussion()
        {
            var command = new EditDiscussionCommand()
            {
                DiscussionId = 0,
                FirstPost = "Macie jakieś hobby? Jak tak to jakie?"
            };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Discussion with gaved id could not update, because not exists in database. " +
                    "Give another id.");
        }
    }
}
