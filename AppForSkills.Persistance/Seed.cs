using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillPost>(d =>
            {
                d.HasData(new SkillPost()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    AddressOfPhotoOrVideo = "images/firstPost.jpg",
                    Title = "Start",
                    Description = "Cześć. W tej części aplikacji będziesz mógł zaprezentować pozostałym użytkownikom " +
                    "swoje umiejętności/talenty w formie zdjęcia, bądź filmiku. Dodać do niego tytuł i opis. " +
                    "Każdy użytkownik, może oceniać, komentować dany post. Baw się dobrze!",
                    UserId = 1
                },
                new SkillPost()
                {
                    Id = 2,
                    StatusId = 2,
                    Created = DateTime.Now,
                    CreatedBy = "Podróżnik",
                    AddressOfPhotoOrVideo = "images/Eiffel_Tower.jpg",
                    Title = "Wieża Eiffla",
                    Description = "Cześć. Autorskie zdjęcie wieży Eiffla",
                    UserId = 2
                }
                );
            });

            modelBuilder.Entity<Comment>().HasData(
                new Comment() { Id = 1, CommentText = "Wow! Super zdjęcie.", CreatedBy = "Turysta12", Created = DateTime.Now,
                    SkillPostId = 2, UserId = 3 },
                new Comment() { Id = 2, CommentText = "Dzięki.", CreatedBy = "Podrożnik", Created = DateTime.Now,
                    SkillPostId = 2, UserId = 2, ParentCommentId = 1}
                );

            modelBuilder.Entity<Rating>().HasData(
                new Rating() { Id = 1, Created = DateTime.Now, CreatedBy = "Turysta12", SkillPostId = 2, UserId = 3, Value = 5 },
                new Rating() { Id = 2, Created = DateTime.Now, CreatedBy = "SuperAdmin", SkillPostId = 2, UserId = 1, Value = 4 }
                );

            modelBuilder.Entity<Like>().HasData(
                new Like() { Id = 1, CommentId = 1, User = "Podróżnik"},
                new Like() { Id = 2, CommentId = 2, User = "Turysta12"},
                new Like() { Id = 3, CommentId = 1, User = "SuperAdmin"},
                new Like() { Id = 4, DiscussionId = 1, User = "Podróżnik" },
                new Like() { Id = 5, DiscussionId = 2, User = "Turysta12" },
                new Like() { Id = 6, DiscussionId = 2, User = "SuperAdmin" },
                new Like() { Id = 7, PostInDiscussionId = 1, User = "Podróżnik"},
                new Like() { Id = 8, PostInDiscussionId = 3, User = "Podróżnik" }
                );
            modelBuilder.Entity<Discussion>(d =>
            {
                d.HasData(new Discussion()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    FirstPost = "Cześć. W tej części aplikacji będziesz mógł rozpoczynać dyskusje, bądź udzielać się " +
                    "już w istniejących.",
                    CreatedBy = "SuperAdmin"
                },
                new Discussion()
                {
                    Id = 2,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Podróżnik",
                    FirstPost = "Jaki kraj chcielibyście odwiedzić?"
                }
                );
            });

            modelBuilder.Entity<PostInDiscussion>().HasData(
                new PostInDiscussion() { Id = 1, DiscussionId = 2, PostText = "Australia", Created = DateTime.Now, 
                    CreatedBy = "Turysta12", StatusId = 1},
                new PostInDiscussion() { Id = 2, StatusId = 1, Created = DateTime.Now, CreatedBy = "Podróżnik", 
                    DiscussionId = 2, ParentPostId = 1, PostText = "Dlaczego?"},
                new PostInDiscussion() { Id = 3, Created = DateTime.Now, CreatedBy = "Turysta12", DiscussionId = 2, 
                    ParentPostId = 2, PostText = "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).",
                    StatusId = 1},
                new PostInDiscussion() { Id = 4, Created = DateTime.Now, CreatedBy = "Podróżnik", DiscussionId = 1,
                    PostText = "Jasne.", StatusId = 1},
                new PostInDiscussion() { Id = 5, DiscussionId = 2, PostText = "Włochy", Created = DateTime.Now,
                    CreatedBy = "SuperAdmin", StatusId = 1},
                new PostInDiscussion() { Id = 6, StatusId = 1, Created = DateTime.Now, CreatedBy = "SuperAdmin",
                    DiscussionId = 2, ParentPostId = 1, PostText = "Możesz rozwinąć?"}
                );

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement() { Id = 1, Name = "Świerzak", Description = "Dodano pierwszy post."},
                new Achievement() { Id = 2, Name = "Początkujący mówca", Description = "Rozpoczęto pierwszą dyskusję." },
                new Achievement() { Id = 3, Name = "Pierwsze udzielenie się", Description = "Dodano pierwszy post do dyskusji."}
                );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Username = "SuperAdmin" },
                new User() { Id = 2, Username = "Podróżnik"},
                new User() { Id = 3, Username = "Turysta12"}
                );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("DiscussionUser")
                .HasData(
                    new { DiscussionsId = 2, UsersInDiscussionId = 2 },
                    new { DiscussionsId = 2, UsersInDiscussionId = 3 },
                    new { DiscussionsId = 2, UsersInDiscussionId = 1 },
                    new { DiscussionsId = 1, UsersInDiscussionId = 1 },
                    new { DiscussionsId = 1, UsersInDiscussionId = 2 }
                );
        }
    }
}
