using AppForSkills.Application.Users.Queries.GetUserComments;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Queries.GetUserComments
{
    [Collection("QueryCollection")]
    public class GetUserCommentsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserCommentsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserCommentsByUsername()
        {
            var handler = new GetUserCommentsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserCommentsQuery { Username = "Podrożnik" }, CancellationToken.None);

            result.ShouldBeOfType<UserCommentsVm>();
            result.Comments.ShouldBeOfType<List<UserCommentDto>>();
            result.Comments.Count.ShouldBe(1);
        }
    }
}
