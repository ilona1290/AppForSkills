using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AppForSkills.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillPost>().HasData(
                new SkillPost()
                { 
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Podróżnik",
                    AddressOfPhotoOrVideo = "https://app.blob.core.windows.net/upload-container/Eiffel_Tower.jpg",
                    Title = "Wieża Eiffla",
                    Description = "Cześć. Autorskie zdjęcie wieży Eiffla",
                    UserId = 1
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    StatusId = 1,
                    CommentText = "Wow! Super zdjęcie.",
                    CreatedBy = "Turysta12",
                    Created = DateTime.Now,
                    SkillPostId = 1,
                    UserId = 2
                },
                new Comment()
                {
                    Id = 2,
                    StatusId = 1,
                    CommentText = "Dzięki.",
                    CreatedBy = "Podróżnik",
                    Created = DateTime.Now,
                    SkillPostId = 1,
                    UserId = 1,
                    MainParentCommentId = 1,
                    ParentCommentId = 1
                });

            modelBuilder.Entity<Rating>().HasData(
                new Rating() { Id = 1, StatusId = 1, Created = DateTime.Now, CreatedBy = "Turysta12", SkillPostId = 1, UserId = 2, Value = 5 });

            modelBuilder.Entity<Like>().HasData(
                new Like() { Id = 1, CommentId = 1, User = "Podróżnik" },
                new Like() { Id = 2, CommentId = 2, User = "Turysta12" },
                new Like() { Id = 3, DiscussionId = 1, User = "Podróżnik" },
                new Like() { Id = 4, DiscussionId = 1, User = "Turysta12" },
                new Like() { Id = 5, PostInDiscussionId = 1, User = "Podróżnik" },
                new Like() { Id = 6, PostInDiscussionId = 3, User = "Podróżnik" }
                );

            modelBuilder.Entity<Discussion>().HasData(
                new Discussion()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Podróżnik",
                    FirstPost = "Jaki kraj chcielibyście odwiedzić?"
                });

            modelBuilder.Entity<PostInDiscussion>().HasData(
                new PostInDiscussion()
                {
                    Id = 1,
                    StatusId = 1,
                    DiscussionId = 1,
                    PostText = "Australia",
                    Created = DateTime.Now,
                    CreatedBy = "Turysta12"
                },
                new PostInDiscussion()
                {
                    Id = 2,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Podróżnik",
                    DiscussionId = 1,
                    MainParentPostId = 1,
                    ParentPostId = 1,
                    PostText = "Dlaczego?"
                },
                new PostInDiscussion()
                {
                    Id = 3,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Turysta12",
                    DiscussionId = 1,
                    MainParentPostId = 1,
                    ParentPostId = 2,
                    PostText = "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :)."
                });

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement() { Id = 1, StatusId = 1, Category = "Skills", Amount = 1, Name = "Początkujący skiller", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/logo1.jpg" },
                new Achievement() { Id = 2, StatusId = 1, Category = "Skills", Amount = 5, Name = "Szał umiejętności"},
                new Achievement() { Id = 3, StatusId = 1, Category = "Skills", Amount = 10, Name = "SkillMaster"},
                new Achievement() { Id = 4, StatusId = 1, Category = "Skills", Amount = 15, Name = "Co za utalentowana bestia"},
                new Achievement() { Id = 5, StatusId = 1, Category = "Skills", Amount = 25, Name = "SkillGod"},
                new Achievement() { Id = 6, StatusId = 1, Category = "Comments", Amount = 5, Name = "Coś tam sobie pomamrocze"},
                new Achievement() { Id = 7, StatusId = 1, Category = "Comments", Amount = 25, Name = "Buszujący w komentarzach"},
                new Achievement() { Id = 8, StatusId = 1, Category = "Comments", Amount = 50, Name = "Komentator-niekoniecznie sportowy"},
                new Achievement() { Id = 9, StatusId = 1, Category = "Comments", Amount = 100, Name = "Imperator-komentator"},
                new Achievement() { Id = 10, StatusId = 1, Category = "Comments", Amount = 125, Name = "Mógłby/Mogłaby napisać książkę, ale pisze komentarze" },
                new Achievement() { Id = 11, StatusId = 1, Category = "Ratings", Amount = 1, Name = "Dam Ci gwiazdkę z nieba", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/logo1.jpg" },
                new Achievement() { Id = 12, StatusId = 1, Category = "Ratings", Amount = 5, Name = "Taniec z gwiazdami" },
                new Achievement() { Id = 13, StatusId = 1, Category = "Ratings", Amount = 15, Name = "Mówcie mi StarLord" },
                new Achievement() { Id = 14, StatusId = 1, Category = "Ratings", Amount = 25, Name = "Mamo, możemy mieć własną konstelacje w domu?" },
                new Achievement() { Id = 15, StatusId = 1, Category = "Ratings", Amount = 50, Name = "Dał/Dała tyle gwiazdek, że może nakręcić własny teledysk Shooting Stars" },
                new Achievement() { Id = 16, StatusId = 1, Category = "Discussions", Amount = 1, Name = "Chcę coś oznajmić", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/logo1.jpg" },
                new Achievement() { Id = 17, StatusId = 1, Category = "Discussions", Amount = 5, Name = "Zawsze musi być jakieś ALE" },
                new Achievement() { Id = 18, StatusId = 1, Category = "Discussions", Amount = 25, Name = "Naczelny Gaduła" },
                new Achievement() { Id = 19, StatusId = 1, Category = "Discussions", Amount = 50, Name = "Dyskutant-Alfa" },
                new Achievement() { Id = 20, StatusId = 1, Category = "Discussions", Amount = 100, Name = "Crushin' discussion" },
                new Achievement() { Id = 21, StatusId = 1, Category = "DiscussionPosts", Amount = 5, Name = "Ja tu tylko dyskutuję" },
                new Achievement() { Id = 22, StatusId = 1, Category = "DiscussionPosts", Amount = 15, Name = "Mam coś więcej do powiedzenia niż tylko ALE" },
                new Achievement() { Id = 23, StatusId = 1, Category = "DiscussionPosts", Amount = 25, Name = "Prowadzący Talk-Show" },
                new Achievement() { Id = 24, StatusId = 1, Category = "DiscussionPosts", Amount = 50, Name = "Nie zwrócimy Ci czasu jaki spędziłeś na pisaniu tych postów" },
                new Achievement() { Id = 25, StatusId = 1, Category = "DiscussionPosts", Amount = 200, Name = "200 postów już gotowych, milion kolejnych w drodze..." }
                );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, StatusId = 1, Username = "Podróżnik", RegistrationDate = DateTime.Now, RecentLoginDate = DateTime.Now },
                new User() { Id = 2, StatusId = 1, Username = "Turysta12", RegistrationDate = DateTime.Now, RecentLoginDate = DateTime.Now }
                );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("DiscussionUser")
                .HasData(
                    new { DiscussionsId = 1, UsersInDiscussionId = 1 },
                    new { DiscussionsId = 1, UsersInDiscussionId = 2 }
                );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AchievementUser")
                .HasData(
                    new { AchievementsId = 1, UsersWithAchivementId = 1 },
                    new { AchievementsId = 11, UsersWithAchivementId = 2 },
                    new { AchievementsId = 16, UsersWithAchivementId = 1 },
                    new { AchievementsId = 16, UsersWithAchivementId = 2 }
                );
        }
    }
}
