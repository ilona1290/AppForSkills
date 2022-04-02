using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using AppForSkills.Application.Exceptions;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Discussion.Queries.GetDiscussion
{
    [Collection("QueryCollection")]
    public class GetDiscussionQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscussionQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetDiscussionDetailById()
        {
            var handler = new GetDiscussionQueryHandler(_context, _mapper);
            var discussionId = 2;

            var result = await handler.Handle(new GetDiscussionQuery { DiscussionId = discussionId }, CancellationToken.None);

            result.ShouldBeOfType<DiscussionVm>();
            result.Posts.ShouldBeOfType<List<PostInDiscussionDto>>();
            result.Posts.Count.ShouldBe(0);
            result.FirstPost.ShouldBe("Jakie sporty uprawiacie?");
        }

        [Fact]
        public void CantGetDiscussionDetailById()
        {
            var handler = new GetDiscussionQueryHandler(_context, _mapper);
            var discussionId = 4;

            var exception = Should.Throw<Exception>(async () => await handler
                .Handle(new GetDiscussionQuery { DiscussionId = discussionId }, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Discussion with gaved id could not display, because not exists in database. " +
                    "Give another id.");
        }
    }
}
