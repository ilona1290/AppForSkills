using AppForSkills.Application.SkillPosts.Commands.CreateRating;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.CreateRating
{
    public class CreateRatingCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly CreateRatingCommandHandler _handler;
        private readonly IMapper _mapper;
        public CreateRatingCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new CreateRatingCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertRatingToSkillPost()
        {
            var command = new CreateRatingCommand()
            {
                SkillPostId = 1,
                Value = 5
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var rating = await _context.Ratings.FirstAsync(x => x.Id == result, CancellationToken.None);

            rating.ShouldNotBeNull();
            rating.Id.ShouldBe(result);
            rating.Value.ShouldBe(5);
        }
    }
}
