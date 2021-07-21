using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class Added_example_of_post_comment_and_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 18, 2, 10, 648, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "Id", "RecentLoginDate", "RegistrationDate", "Username" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podrożnik" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turysta12" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "SkillId", "SkillPostId", "StatusId", "UserId", "Value" },
                values: new object[] { 1, new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(6164), "Turysta12", null, null, null, null, 2, null, 0, 3, 5 });

            migrationBuilder.InsertData(
                table: "SkillPosts",
                columns: new[] { "Id", "Address", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Title", "UserId", "Views" },
                values: new object[] { 2, "images/Eiffel_Tower.jpg", new DateTime(2021, 7, 21, 18, 2, 10, 660, DateTimeKind.Local).AddTicks(1276), "Podrożnik", "Cześć. Autorskie zdjęcie wieźy Eiffla", null, null, null, null, 2, "Wieża Eiffla", 2, 0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "CommentText", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentCommentId", "SkillPostId", "StatusId", "UserId" },
                values: new object[] { 1, null, "Wow! Super zdjęcie.", new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(3650), "Turysta12", null, null, null, null, null, 2, 0, 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "CommentText", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentCommentId", "SkillPostId", "StatusId", "UserId" },
                values: new object[] { 2, null, "Dzięki.", new DateTime(2021, 7, 21, 18, 2, 10, 661, DateTimeKind.Local).AddTicks(4411), "Podrożnik", null, null, null, null, 1, 2, 0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 8, 19, 47, 14, 480, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 8, 19, 47, 14, 470, DateTimeKind.Local).AddTicks(9276));
        }
    }
}
