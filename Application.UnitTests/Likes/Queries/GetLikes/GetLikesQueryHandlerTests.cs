using AppForSkills.Application.Exceptions;
using AppForSkills.Application.Likes.Queries.GetLikes;
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

namespace Application.UnitTests.Likes.Queries.GetLikes
{
    [Collection("QueryCollection")]
    public class GetLikesQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetLikesQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetLikesFromPostInDiscussionById()
        {
            var handler = new GetLikesQueryHandler(_context, _mapper);
            var postInDiscussionId = 3;

            var result = await handler.Handle(new GetLikesQuery { PostInDiscussionId = postInDiscussionId }, CancellationToken.None);

            result.ShouldBeOfType<LikesVm>();
            result.Likes.ShouldBeOfType<List<LikeDto>>();
            result.Likes.Count.ShouldBe(1);
            result.Likes[0].Username.ShouldBe("Podróżnik");
        }

        [Fact]
        public async Task CanGetLikesFromDiscussionById()
        {
            var handler = new GetLikesQueryHandler(_context, _mapper);
            var discussionId = 1;

            var result = await handler.Handle(new GetLikesQuery { DiscussionId = discussionId }, CancellationToken.None);

            result.ShouldBeOfType<LikesVm>();
            result.Likes.ShouldBeOfType<List<LikeDto>>();
            result.Likes.Count.ShouldBe(2);
            result.Likes[0].Username.ShouldBe("Podróżnik");
        }

        [Fact]
        public async Task CanGetLikesFromCommentById()
        {
            var handler = new GetLikesQueryHandler(_context, _mapper);
            var commentId = 1;

            var result = await handler.Handle(new GetLikesQuery { CommentId = commentId }, CancellationToken.None);

            result.ShouldBeOfType<LikesVm>();
            result.Likes.ShouldBeOfType<List<LikeDto>>();
            result.Likes.Count.ShouldBe(1);
            result.Likes[0].Username.ShouldBe("Podróżnik");
        }

        [Fact]
        public void CantGetLikesByNotGivingId()
        {
            var handler = new GetLikesQueryHandler(_context, _mapper);

            var exception = Should.Throw<Exception>(async () => await handler
                .Handle(new GetLikesQuery(), CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("You gaved wrong Id, give another Id.");
        }
    }
}
