using AppForSkills.Application.Discussions.Commands.CreatePost;
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

namespace Application.UnitTests.Discussion.Commands.CreatePost
{
    public class CreatePostCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly CreatePostCommandHandler _handler;
        private readonly IMapper _mapper;

        public CreatePostCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new CreatePostCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertPostToDiscussion()
        {
            var command = new CreatePostCommand()
            {
                DiscussionId = 3,
                PostText = "Siatkówkę"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var post = await _context.PostsInDiscussion.FirstAsync(x => x.Id == result, CancellationToken.None);

            post.ShouldNotBeNull();
            post.Id.ShouldBe(result);
        }
    }
}
