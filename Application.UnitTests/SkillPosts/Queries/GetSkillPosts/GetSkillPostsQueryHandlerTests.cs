using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Queries.GetSkillPosts
{
    [Collection("QueryCollection")]
    public class GetSkillPostsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetSkillPostsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetSkillPosts()
        {
            var handler = new GetSkillPostsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetSkillPostsQuery(), CancellationToken.None);

            result.ShouldBeOfType<SkillPostsVm>();
            result.SkillPosts.ShouldBeOfType<List<SkillPostDto>>();
            result.SkillPosts.Count.ShouldBe(1);
        }
    }
}
