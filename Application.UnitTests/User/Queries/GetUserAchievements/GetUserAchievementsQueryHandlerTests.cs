using AppForSkills.Application.Users.Queries.GetUserAchievements;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Queries.GetUserAchievements
{
    [Collection("QueryCollection")]
    public class GetUserAchievementsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserAchievementsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserAchievementsByUsername()
        {
            var handler = new GetUserAchievementsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserAchievementsQuery { Username = "Podróżnik" }, CancellationToken.None);

            result.ShouldBeOfType<AchievementsVm>();
            result.Achievements.ShouldBeOfType<List<AchievementDto>>();
            result.Achievements.Count.ShouldBe(3);
        }
    }
}
