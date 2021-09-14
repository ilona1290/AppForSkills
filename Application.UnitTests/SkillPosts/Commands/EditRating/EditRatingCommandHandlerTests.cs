using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.EditRating;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.EditRating
{
    public class EditRatingCommandHandlerTests : CommandTestBase
    {
        private readonly EditRatingCommandHandler _handler;

        public EditRatingCommandHandlerTests() : base()
        {
            _handler = new EditRatingCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditRating()
        {
            var command = new EditRatingCommand()
            {
                Id = 2,
                Value = 3
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var rating = await _context.Ratings.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            rating.ModifiedBy.ShouldBe("user");
            rating.Value.ShouldBe(command.Value);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntEditRating()
        {
            var command = new EditRatingCommand()
            {
                Id = 0,
                Value = 3
            };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Rating with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
        }
    }
}
