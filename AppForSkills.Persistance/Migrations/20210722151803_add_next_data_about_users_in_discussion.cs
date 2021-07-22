using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class add_next_data_about_users_in_discussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 971, DateTimeKind.Local).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.InsertData(
                table: "DiscussionUserInformation",
                columns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentPostId", "PostInDiscussionId", "PostText", "Reported", "StatusId" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9478), "SuperAdmin", 2, null, null, null, null, null, null, "Włochy", false, 1 },
                    { 6, new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(9481), "SuperAdmin", 2, null, null, null, null, 1, null, "Możesz rozwinąć?", false, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 972, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 963, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 17, 18, 1, 970, DateTimeKind.Local).AddTicks(6193));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscussionUserInformation",
                keyColumns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 218, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 218, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 219, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 218, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 218, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 210, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 16, 4, 36, 216, DateTimeKind.Local).AddTicks(7245));
        }
    }
}
