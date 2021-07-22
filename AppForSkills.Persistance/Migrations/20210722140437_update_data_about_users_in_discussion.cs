using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class update_data_about_users_in_discussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5);

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
                columns: new[] { "Created", "CreatedBy", "DiscussionId", "ParentPostId", "PostText" },
                values: new object[] { new DateTime(2021, 7, 22, 16, 4, 36, 220, DateTimeKind.Local).AddTicks(5993), "Podróżnik", 1, null, "Jasne." });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "CreatedBy", "DiscussionId", "ParentPostId", "PostText" },
                values: new object[] { new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2652), "Turysta12", 2, 2, "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :)." });

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentPostId", "PostInDiscussionId", "PostText", "Reported", "StatusId" },
                values: new object[] { 5, new DateTime(2021, 7, 22, 15, 34, 30, 102, DateTimeKind.Local).AddTicks(2656), "Podróżnik", 1, null, null, null, null, null, null, "Jasne.", false, 1 });

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
    }
}
