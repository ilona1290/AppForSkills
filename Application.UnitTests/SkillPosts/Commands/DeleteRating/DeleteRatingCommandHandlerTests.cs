using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.DeleteRating;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.DeleteRating
{
    public class DeleteRatingCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteRatingCommandHandler _handler;

        public DeleteRatingCommandHandlerTests() : base()
        {
            _handler = new DeleteRatingCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteRating()
        {
            var command = new DeleteRatingCommand() { RatingId = 2 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var rating = await _context.Ratings.FirstAsync(x => x.Id == command.RatingId, CancellationToken.None);

            rating.StatusId.ShouldBe(0);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntDeleteRating()
        {
            var command = new DeleteRatingCommand() { RatingId = 0 };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Rating with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
