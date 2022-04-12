using AppForSkills.Application.Likes.Commands.GiveLike;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Likes.Commands.GiveLike
{
    public class GiveLikeCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly GiveLikeCommandHandler _handler;
        private readonly IMapper _mapper;

        public GiveLikeCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new GiveLikeCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertLikeToPostInDiscussion()
        {
            var command = new GiveLikeCommand()
            {
                User = "user",
                PostInDiscussionId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var like = await _context.Likes.FirstAsync(x => x.User == command.User, CancellationToken.None);

            like.ShouldNotBeNull();
            like.PostInDiscussionId.ShouldBe(command.PostInDiscussionId);
            like.DiscussionId.ShouldBeNull();
            like.CommentId.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertLikeToDiscussion()
        {
            var command = new GiveLikeCommand()
            {
                User = "user",
                DiscussionId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var like = await _context.Likes.FirstAsync(x => x.User == command.User, CancellationToken.None);

            like.ShouldNotBeNull();
            like.DiscussionId.ShouldBe(command.DiscussionId);
            like.PostInDiscussionId.ShouldBeNull();
            like.CommentId.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertLikeToComment()
        {
            var command = new GiveLikeCommand()
            {
                User = "user",
                CommentId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var like = await _context.Likes.FirstAsync(x => x.User == command.User, CancellationToken.None);

            like.ShouldNotBeNull();
            like.CommentId.ShouldBe(command.CommentId);
            like.PostInDiscussionId.ShouldBeNull();
            like.DiscussionId.ShouldBeNull();
        }
    }
}
