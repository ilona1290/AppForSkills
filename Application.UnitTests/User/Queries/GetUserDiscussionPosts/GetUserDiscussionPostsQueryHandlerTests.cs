using AppForSkills.Application.Users.Queries.GetUserDiscussionPosts;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Queries.GetUserDiscussionPosts
{
    [Collection("QueryCollection")]
    public class GetUserDiscussionPostsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDiscussionPostsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserDiscussionPostsByUsername()
        {
            var handler = new GetUserDiscussionPostsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserDiscussionPostsQuery { Username = "Podróżnik" }, CancellationToken.None);

            result.ShouldBeOfType<UserDiscussionPostsVm>();
            result.DiscussionPosts.ShouldBeOfType<List<UserDiscussionPostDto>>();
            result.DiscussionPosts.Count.ShouldBe(3);
        }
    }
}
