using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace Application.UnitTests.Common
{
    public class AppForSkillsDbContextFactory
    {
        public static Mock<AppForSkillsDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<ICurrentUserService>();
            currentUserMock.Setup(m => m.Username).Returns("user");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<AppForSkillsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<AppForSkillsDbContext>(options, dateTimeMock.Object, currentUserMock.Object) { CallBase = true };

            var context = mock.Object;

            context.Database.EnsureCreated();

            var user = new AppForSkills.Domain.Entities.User()
            {
                Id = 3,
                Username = "user",
                RegistrationDate = new DateTime(1999, 12, 29),
                RecentLoginDate = new DateTime(2000, 1, 1),
                StatusId = 1
            };
            context.Users.Add(user);

            var discussion = new AppForSkills.Domain.Entities.Discussion()
            {
                Id = 2,
                FirstPost = "Jakie sporty uprawiacie?",
                StatusId = 1,
                CreatedBy = "user"
            };
            context.Discussions.Add(discussion);

            var postInDiscussion = new AppForSkills.Domain.Entities.PostInDiscussion()
            {
                Id = 4,
                DiscussionId = 1,
                PostText = "Francję",
                StatusId = 1,
                CreatedBy = "user",
                UserId = 3
            };
            context.PostsInDiscussion.Add(postInDiscussion);


            

            context.SaveChanges();
            return mock;
        }

        public static void Destroy(AppForSkillsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
