using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class add_likes_to_example_skill_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 44, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Podróżnik" },
                    { 2, 2, null, null, "Turysta12" },
                    { 3, 1, null, null, "SuperAdmin" }
                });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 35, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description" },
                values: new object[] { new DateTime(2021, 7, 21, 19, 27, 13, 42, DateTimeKind.Local).AddTicks(4477), "Cześć. Autorskie zdjęcie wieży Eiffla" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 648, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description" },
                values: new object[] { new DateTime(2021, 7, 21, 18, 2, 10, 660, DateTimeKind.Local).AddTicks(1276), "Cześć. Autorskie zdjęcie wieźy Eiffla" });
        }
    }
}
