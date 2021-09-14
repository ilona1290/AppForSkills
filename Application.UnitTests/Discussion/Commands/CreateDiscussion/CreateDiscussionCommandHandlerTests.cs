using AppForSkills.Application.Discussions.Commands.CreateDiscussion;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Discussion.Commands.CreateDiscussion
{
    public class CreateDiscussionCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly CreateDiscussionCommandHandler _handler;
        private readonly IMapper _mapper;

        public CreateDiscussionCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new CreateDiscussionCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertDiscussion()
        {
            var command = new CreateDiscussionCommand()
            {
                FirstPost = "Jakie jest Wasze hobby?"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var dis = await _context.Discussions.FirstAsync(x => x.Id == result, CancellationToken.None);

            dis.ShouldNotBeNull();
            dis.Id.ShouldBe(result);
        }
    }
}
