using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class add_data_about_users_in_discussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 101, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 101, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.InsertData(
                table: "DiscussionUserInformation",
                columns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentPostId", "PostInDiscussionId", "PostText", "Reported", "StatusId" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2652), "Turysta12", 2, null, null, null, null, 2, null, "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).", false, 1 },
                    { 5, new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2656), "Podróżnik", 1, null, null, null, null, null, null, "Jasne.", false, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 101, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 101, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 93, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 15, 34, 30, 99, DateTimeKind.Local).AddTicks(7522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscussionUserInformation",
                keyColumns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DiscussionUserInformation",
                keyColumns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DiscussionUserInformation",
                keyColumns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DiscussionUserInformation",
                keyColumns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5);

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
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 914, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 7, 22, 13, 9, 34, 915, DateTimeKind.Local).AddTicks(2523));

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
        }
    }
}
