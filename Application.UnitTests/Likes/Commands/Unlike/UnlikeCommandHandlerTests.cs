using AppForSkills.Application.Likes.Commands.Unlike;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Likes.Commands.Unlike
{
    public class UnlikeCommandHandlerTests : CommandTestBase
    {
        private readonly UnlikeCommandHandler _handler;

        public UnlikeCommandHandlerTests() : base()
        {
            _handler = new UnlikeCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteLike()
        {
            var command = new UnlikeCommand() { LikeId = 3 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var discussion = await _context.Discussions.FirstAsync(x => x.Id == command.LikeId, CancellationToken.None);

            discussion.StatusId.CompareTo(0);
        }
    }
}
