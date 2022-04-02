using AppForSkills.Application.Discussions.Commands.EditPost;
using AppForSkills.Application.Exceptions;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Discussion.Commands.EditPost
{
    public class EditPostCommandHandlerTests : CommandTestBase
    {
        private readonly EditPostCommandHandler _handler;

        public EditPostCommandHandlerTests() : base()
        {
            _handler = new EditPostCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditPost()
        {
            var command = new EditPostCommand()
            {
                Id = 4,
                PostText = "USA"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var post = await _context.PostsInDiscussion.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            post.ModifiedBy.ShouldBe("user");
            post.PostText.ShouldBe(command.PostText);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntEditPost()
        {
            var command = new EditPostCommand()
            {
                Id = 0,
                PostText = "Koszykówkę"
            };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Post with gaved id could not update, because not exists in database. " +
                    "Give another id.");
        }
    }
}
