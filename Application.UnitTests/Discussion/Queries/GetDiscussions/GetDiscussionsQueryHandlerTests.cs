using AppForSkills.Application.Discussions.GetDiscussions;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Discussion.Queries.GetDiscussions
{
    [Collection("QueryCollection")]
    public class GetDiscussionsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscussionsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetDiscussions()
        {
            var handler = new GetDiscussionsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetDiscussionsQuery(), CancellationToken.None);

            result.ShouldBeOfType<DiscussionsVm>();
            result.Discussions.ShouldBeOfType<List<DiscussionDto>>();
            result.Discussions.Count.ShouldBe(2);
        }
    }
}
