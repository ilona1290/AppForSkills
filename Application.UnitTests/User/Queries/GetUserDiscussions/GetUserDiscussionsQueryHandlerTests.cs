using AppForSkills.Application.Discussions.GetDiscussions;
using AppForSkills.Application.Users.Queries.GetUserDiscussions;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Queries.GetUserDiscussions
{
    [Collection("QueryCollection")]
    public class GetUserDiscussionsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDiscussionsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserDiscussionsByUsername()
        {
            var handler = new GetUserDiscussionsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserDiscussionsQuery { Username = "Podróżnik" }, CancellationToken.None);

            result.ShouldBeOfType<DiscussionsVm>();
            result.Discussions.ShouldBeOfType<List<DiscussionDto>>();
            result.Discussions.Count.ShouldBe(2);
        }
    }
}
