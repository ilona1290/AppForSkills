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
                    CreatedBy = "Podrożnik",
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
                new Rating() { Id = 1, Value = 5, SkillId = 2, Created = DateTime.Now, CreatedBy = "Turysta12", UserId = 3},
                new Rating() { Id = 2, Value = 4, SkillId = 2, Created = DateTime.Now, CreatedBy = "SuperAdmin", UserId = 1}
                );

            modelBuilder.Entity<Like>().HasData(
                new Like() { Id = 1, CommentId = 1, User = "Podróżnik"},
                new Like() { Id = 2, CommentId = 2, User = "Turysta12"},
                new Like() { Id = 3, CommentId = 1, User = "SuperAdmin"}
                );
            modelBuilder.Entity<Discussion>(d =>
            {
                d.HasData(new Discussion()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    FirstPost = "Cześć. W tej części aplikacji będziesz mógł rozpoczynać dyskusje, bądź udzielać się " +
                    "już w istniejących."
                });
            });

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement() { Id = 1, Name = "Świerzak", Description = "Dodano pierwszy post."},
                new Achievement() { Id = 2, Name = "Początkujący mówca", Description = "Rozpoczęto pierwszą dyskusję." },
                new Achievement() { Id = 3, Name = "Pierwsze udzielenie się", Description = "Dodano pierwszy post do dyskusji."}
                );

            modelBuilder.Entity<UserInformation>().HasData(
                new UserInformation() { Id = 1, Username = "SuperAdmin" },
                new UserInformation() { Id = 2, Username = "Podrożnik"},
                new UserInformation() { Id = 3, Username = "Turysta12"}
                );
        }
    }
}
