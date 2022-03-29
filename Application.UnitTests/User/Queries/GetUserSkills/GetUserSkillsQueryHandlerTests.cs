using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using AppForSkills.Application.Users.Queries.GetUserSkills;
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

namespace Application.UnitTests.User.Queries.GetUserSkills
{
    [Collection("QueryCollection")]
    public class GetUserSkillsQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserSkillsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserSkillsByUsername()
        {
            var handler = new GetUserSkillsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserSkillsQuery { Username = "Podróżnik" }, CancellationToken.None);

            result.ShouldBeOfType<SkillPostsVm>();
            result.SkillPosts.ShouldBeOfType<List<SkillPostDto>>();
            result.SkillPosts.Count.ShouldBe(1);
            result.SkillPosts[0].Title.ShouldBe("Wieża Eiffla");
        }
    }
}
