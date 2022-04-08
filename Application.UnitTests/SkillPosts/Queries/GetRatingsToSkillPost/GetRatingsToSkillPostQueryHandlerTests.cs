using AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Queries.GetRatingsToSkillPost
{
    [Collection("QueryCollection")]
    public class GetRatingsToSkillPostQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetRatingsToSkillPostQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetRatingsSkillPosts()
        {
            var handler = new GetRatingsToSkillPostQueryHandler(_context, _mapper);
            var skillId = 1;

            var result = await handler.Handle(new GetRatingsToSkillPostQuery { SkillId = skillId }, CancellationToken.None);

            result.ShouldBeOfType<RatingsPostVm>();
            result.RatingsPost.ShouldBeOfType<List<RatingPostDto>>();
            result.RatingsPost.Count.ShouldBe(1);
        }
    }
}
