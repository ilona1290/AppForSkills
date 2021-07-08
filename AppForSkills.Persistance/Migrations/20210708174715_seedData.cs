using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Achievements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "Achievement" },
                values: new object[,]
                {
                    { 1, "Dodano pierwszy post.", "Świerzak" },
                    { 2, "Rozpoczęto pierwszą dyskusję.", "Początkujący mówca" },
                    { 3, "Dodano pierwszy post do dyskusji.", "Pierwsze udzielenie się" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Created", "CreatedBy", "FirstPost", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { 1, new DateTime(2021, 7, 8, 19, 47, 14, 480, DateTimeKind.Local).AddTicks(8831), null, "Cześć. W tej części aplikacji będziesz mógł rozpoczynać dyskusje, bądź udzielać się już w istniejących.", null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "Id", "RecentLoginDate", "RegistrationDate", "Username" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "SkillPosts",
                columns: new[] { "Id", "Address", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Title", "UserId", "Views" },
                values: new object[] { 1, "images/firstPost.jpg", new DateTime(2021, 7, 8, 19, 47, 14, 470, DateTimeKind.Local).AddTicks(9276), null, "Cześć. W tej części aplikacji będziesz mógł zaprezentować pozostałym użytkownikom swoje umiejętności/talenty w formie zdjęcia, bądź filmiku. Dodać do niego tytuł i opis. Każdy użytkownik, może oceniać, komentować dany post. Baw się dobrze!", null, null, null, null, 1, "Start", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Achievements");
        }
    }
}
