using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class change_in_configuration_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 893, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 893, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 894, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 893, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 893, DateTimeKind.Local).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 884, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 12, 25, 892, DateTimeKind.Local).AddTicks(3228));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 500, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 499, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 488, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 13, 22, 48, 497, DateTimeKind.Local).AddTicks(630));
        }
    }
}
