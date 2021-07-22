using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class added_data_to_Discussions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 913, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(7656), "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Created", "CreatedBy", "FirstPost", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { 2, new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(8078), "Podróżnik", "Jaki kraj chcielibyście odwiedzić?", null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 4, null, 1, null, "Podróżnik" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 906, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 912, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 5, null, 2, null, "Turysta12" },
                    { 6, null, 2, null, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentPostId", "PostInDiscussionId", "PostText", "Reported", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(1624), "Turysta12", 2, null, null, null, null, null, null, "Australia", false, 1 },
                    { 2, new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(1702), "Podróżnik", 2, null, null, null, null, 1, null, "Dlaczego?", false, 1 },
                    { 3, new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(2523), "Turysta12", 2, null, null, null, null, 2, null, "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 7, null, null, 1, "Podróżnik" });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 8, null, null, 3, "Podróżnik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 38, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 38, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2021, 7, 21, 22, 24, 10, 39, DateTimeKind.Local).AddTicks(4218), null });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 39, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 39, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 31, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 37, DateTimeKind.Local).AddTicks(6978));
        }
    }
}
