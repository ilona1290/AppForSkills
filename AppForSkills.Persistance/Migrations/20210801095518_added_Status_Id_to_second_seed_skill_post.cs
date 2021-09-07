using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppForSkills.Persistance.Migrations
{
    public partial class added_Status_Id_to_second_seed_skill_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 927, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 928, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 55, 17, 920, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 55, 17, 926, DateTimeKind.Local).AddTicks(8135), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 780, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 770, DateTimeKind.Local).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 52, 36, 777, DateTimeKind.Local).AddTicks(4242), 2 });
        }
    }
}
