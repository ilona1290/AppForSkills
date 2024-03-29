﻿using AppForSkills.Domain.Entities;
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
                    AddressOfPhotoOrVideo = "https://appforskills1.blob.core.windows.net/upload-container/Eiffel_Tower.jpg",
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
                new Like() { Id = 1, CommentId = 1, User = "Podróżnik", Avatar = "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg" },
                new Like() { Id = 2, CommentId = 2, User = "Turysta12" },
                new Like() { Id = 3, DiscussionId = 1, User = "Podróżnik", Avatar = "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg" },
                new Like() { Id = 4, DiscussionId = 1, User = "Turysta12" },
                new Like() { Id = 5, PostInDiscussionId = 1, User = "Podróżnik", Avatar = "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg" },
                new Like() { Id = 6, PostInDiscussionId = 3, User = "Podróżnik", Avatar = "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg" }
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
                    CreatedBy = "Turysta12",
                    UserId = 2
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
                    PostText = "Dlaczego?",
                    UserId = 1
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
                    PostText = "@Podróżnik Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).",
                    UserId = 2
                });

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement() { Id = 1, StatusId = 1, Category = "Skills", Amount = 1, Name = "Początkujący Skiller", 
                    Description = "Dodano pierwszy SkillPost", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/skill1.png"},
                new Achievement() { Id = 2, StatusId = 1, Category = "Skills", Amount = 5, Name = "Szał umiejętności",
                    Description = "Dodano 5 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/skill2.png"},
                new Achievement() { Id = 3, StatusId = 1, Category = "Skills", Amount = 10, Name = "SkillMaster",
                    Description = "Dodano 10 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/skill3.png"},
                new Achievement() { Id = 4, StatusId = 1, Category = "Skills", Amount = 15, Name = "Co za utalentowana bestia",
                    Description = "Dodano 15 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/skill4.png"},
                new Achievement() { Id = 5, StatusId = 1, Category = "Skills", Amount = 25, Name = "SkillGod",
                    Description = "Dodano 25 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/skill5.png"},
                new Achievement() { Id = 6, StatusId = 1, Category = "Komentarze", Amount = 5, Name = "Coś tam sobie pomamrocze",
                    Description = "Dodano 5 Komentarzy", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/kom1.png"},
                new Achievement() { Id = 7, StatusId = 1, Category = "Komentarze", Amount = 25, Name = "Buszujący w komentarzach",
                    Description = "Dodano 25 Komentarzy", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/kom2.png"},
                new Achievement() { Id = 8, StatusId = 1, Category = "Komentarze", Amount = 50, Name = "Komentator-niekoniecznie-sportowy",
                    Description = "Dodano 50 Komentarzy", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/kom3.png"},
                new Achievement() { Id = 9, StatusId = 1, Category = "Komentarze", Amount = 100, Name = "Imperator-komentator",
                    Description = "Dodano 100 Komentarzy", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/kom4.png"},
                new Achievement() { Id = 10, StatusId = 1, Category = "Komentarze", Amount = 125, Name = "Mógłby/Mogłaby napisać książkę, ale pisze komentarze",
                    Description = "Dodano 125 Komentarzy", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/kom5.png"},
                new Achievement() { Id = 11, StatusId = 1, Category = "Oceny", Amount = 1, Name = "Dam Ci gwiazdkę z nieba",
                    Description = "Oceniono pierwszy SkillPost", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/rat1.png"},
                new Achievement() { Id = 12, StatusId = 1, Category = "Oceny", Amount = 5, Name = "Taniec z gwiazdami",
                    Description = "Oceniono 5 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/rat2.png"},
                new Achievement() { Id = 13, StatusId = 1, Category = "Oceny", Amount = 15, Name = "Mówcie mi StarLord",
                    Description = "Oceniono 15 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/rat3.png"},
                new Achievement() { Id = 14, StatusId = 1, Category = "Oceny", Amount = 25, Name = "Mamo, możemy mieć własną konstelacje w domu?",
                    Description = "Oceniono 25 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/rat4.png"},
                new Achievement() { Id = 15, StatusId = 1, Category = "Oceny", Amount = 50, Name = "Dał/Dała tyle gwiazdek, że może nakręcić własny teledysk Shooting Stars",
                    Description = "Oceniono 50 SkillPost'ów", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/rat5.png"},
                new Achievement() { Id = 16, StatusId = 1, Category = "Dyskusje", Amount = 1, Name = "Chcę coś oznajmić",
                    Description = "Dołączono do pierwszej dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/dis1.png"},
                new Achievement() { Id = 17, StatusId = 1, Category = "Dyskusje", Amount = 5, Name = "Zawsze musi być jakieś ALE",
                    Description = "Dołączono do 5 dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/dis2.png"},
                new Achievement() { Id = 18, StatusId = 1, Category = "Dyskusje", Amount = 25, Name = "Naczelny Gaduła",
                    Description = "Dołączono do 25 dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/dis3.png"},
                new Achievement() { Id = 19, StatusId = 1, Category = "Dyskusje", Amount = 50, Name = "Dyskutant-Alfa",
                    Description = "Dołączono do 50 dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/dis4.png"},
                new Achievement() { Id = 20, StatusId = 1, Category = "Dyskusje", Amount = 100, Name = "Crushin' discussion",
                    Description = "Dołączono do 100 dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/dis5.png"},
                new Achievement() { Id = 21, StatusId = 1, Category = "Posty w dyskusjach", Amount = 1, Name = "Ja tu tylko dyskutuję",
                    Description = "Udzielono się raz w dyskusji", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/pwd1.png"},
                new Achievement() { Id = 22, StatusId = 1, Category = "Posty w dyskusjach", Amount = 15, Name = "Mam coś więcej do powiedzenia niż tylko ALE",
                    Description = "Udzielono się 15 razy w dyskusjach", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/pwd2.png"},
                new Achievement() { Id = 23, StatusId = 1, Category = "Posty w dyskusjach", Amount = 25, Name = "Prowadzący Talk-Show",
                    Description = "Udzielono się 25 razy w dyskusjach", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/pwd3.png"},
                new Achievement() { Id = 24, StatusId = 1, Category = "Posty w dyskusjach", Amount = 50, Name = "Nie zwrócimy Ci czasu jaki spędziłeś na pisaniu tych postów",
                    Description = "Udzielono się 50 razy w dyskusjach", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/pwd4.png"},
                new Achievement() { Id = 25, StatusId = 1, Category = "Posty w dyskusjach", Amount = 200, Name = "200 postów już gotowych, milion kolejnych w drodze...",
                    Description = "Udzielono się 200 razy w dyskusjach", Logo = "https://appforskills1.blob.core.windows.net/achivement-logos/pwd5.png"}
                );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, StatusId = 1, Username = "Podróżnik", RegistrationDate = DateTime.Now, RecentLoginDate = DateTime.Now,
                    Avatar = "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg" },
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
