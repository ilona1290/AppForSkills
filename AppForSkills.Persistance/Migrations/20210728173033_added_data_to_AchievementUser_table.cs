using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class added_data_to_AchievementUser_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AchievementUser",
                columns: new[] { "AchievementsId", "UsersWithAchivementId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 261, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 252, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 30, 32, 259, DateTimeKind.Local).AddTicks(79), "Podróżnik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AchievementUser",
                keyColumns: new[] { "AchievementsId", "UsersWithAchivementId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(1251));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 231, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 19, 54, 25, 223, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2021, 7, 22, 19, 54, 25, 229, DateTimeKind.Local).AddTicks(7726), "Podrożnik" });
        }
    }
}
