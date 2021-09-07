using AppForSkills.Application.Users.Queries.GetUserRatings;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Queries.GetUserRatings
{
    [Collection("QueryCollection")]
    public class GetUserRatingsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserRatingsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserRatingsByUsername()
        {
            var handler = new GetUserRatingsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserRatingsQuery { Username = "Turysta12" }, CancellationToken.None);

            result.ShouldBeOfType<RatingsVm>();
            result.Ratings.ShouldBeOfType<List<RatingDto>>();
            result.Ratings.Count.ShouldBe(1);
            result.Ratings[0].Value.ShouldBe(5);
        }
    }
}
