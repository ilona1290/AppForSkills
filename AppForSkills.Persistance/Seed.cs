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
                });
            });

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
                new UserInformation() { Id = 1, Username = "SuperAdmin" }
                );
        }
    }
}
