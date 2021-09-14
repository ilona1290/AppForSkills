using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.DeleteSkillPost;
using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SkillPosts.Commands.DeleteSkillPost
{
    public class DeleteSkillPostCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteSkillPostCommandHandler _handler;

        public DeleteSkillPostCommandHandlerTests() : base()
        {
            _handler = new DeleteSkillPostCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteSkillPost()
        {
            var command = new DeleteSkillPostCommand() { SkillPostId = 2 };

            var result = await _handler.Handle(command, CancellationToken.None);

            var skillPost = await _context.SkillPosts.FirstAsync(x => x.Id == command.SkillPostId, CancellationToken.None);

            skillPost.StatusId.ShouldBe(0);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldntDeleteSkillPost()
        {
            var command = new DeleteSkillPostCommand() { SkillPostId = 0 };

            var exception = Should.Throw<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            var message = exception.Message;

            exception.ShouldBeOfType<WrongIDException>();
            message.ShouldBe("Skill Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
        }
    }
}
