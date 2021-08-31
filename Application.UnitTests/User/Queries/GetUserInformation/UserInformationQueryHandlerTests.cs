using AppForSkills.Application.Users.Queries.GetUserInformation;
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

namespace Application.UnitTests.User.Queries.GetUserInformation
{
    [Collection("QueryCollection")]
    public class UserInformationQueryHandlerTests
    {
        private readonly AppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public UserInformationQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetUserInformation()
        {
            var handler = new UserInformationQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetUserInformationQuery { Username = "Turysta12" }, CancellationToken.None);

            result.ShouldBeOfType<UserInformationVm>();
            result.UserSkills.ShouldBe(0);
            result.UserComments.ShouldBe(1);
            result.GavedRatings.ShouldBe(1);
            result.Achievements.ShouldBe(1);
            result.Discussions.ShouldBe(1);
        }
    }
}
