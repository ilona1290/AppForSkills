using AppForSkills.Application.Users.Commands.CreateUser;
using Application.UnitTests.Common;
using Application.UnitTests.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.User.Commands.CreateUser
{
    public class CreateUserCommandHandlerTests : CommandTestBase, IClassFixture<MappingTestFixture>
    {
        private readonly CreateUserCommandHandler _handler;
        private readonly IMapper _mapper;

        public CreateUserCommandHandlerTests(MappingTestFixture mappingTestFixture) : base()
        {
            _mapper = mappingTestFixture.Mapper;
            _handler = new CreateUserCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertBussinessUser()
        {
            var command = new CreateUserCommand()
            {
                Username = "user",
                RegistrationDate = new DateTime(1999, 12, 29).ToString(),
                RecentLoginDate = new DateTime(2000, 1, 1).ToString()
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var user = await _context.Users.FirstAsync(x => x.Username == command.Username, CancellationToken.None);

            user.ShouldNotBeNull();
        }
    }
}
