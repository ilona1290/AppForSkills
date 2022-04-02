using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AppForSkills.Persistance;
using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Queries.GetSkillPostDetail
{
    [Collection("QueryCollection")]
    public class GetSkillPostDetailQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetSkillPostDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetSkillPostDetailById()
        {
            var handler = new GetSkillPostDetailQueryHandler(_context, _mapper);
            var skillPostId = 2;

            var result = await handler.Handle(new GetSkillPostDetailQuery { SkillPostId = skillPostId }, CancellationToken.None);

            result.ShouldBeOfType<SkillPostVm>();
            result.Comments.ShouldBeOfType<List<CommentDto>>();
            result.Comments.Count.ShouldBe(2);
            result.AddressOfPhotoOrVideo.ShouldBe("images/Eiffel_Tower.jpg");
            result.Rating.ShouldBe(4, 5);
        }

        [Fact]
        public void CantGetSkillPostDetailById()
        {
            var handler = new GetSkillPostDetailQueryHandler(_context, _mapper);
            var skillPostId = 3;

            var exception = Should.Throw<Exception>(async () => await handler
                .Handle(new GetSkillPostDetailQuery { SkillPostId = skillPostId }, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Skill Post with gaved id could not display, because not exists in database. " +
                    "Give another id.");
        }
    }
}
