using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppForSkills.Persistance.Migrations
{
    public partial class added_Status_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(3832), 1 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(4527), 1 });

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
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(5416), 1 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 8, 1, 11, 52, 36, 779, DateTimeKind.Local).AddTicks(6277), 1 });

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
                column: "Created",
                value: new DateTime(2021, 8, 1, 11, 52, 36, 777, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Achievements");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(1926), 0 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(2621), 0 });

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
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(3636), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 30, 32, 260, DateTimeKind.Local).AddTicks(4548), 0 });

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
                column: "Created",
                value: new DateTime(2021, 7, 28, 19, 30, 32, 259, DateTimeKind.Local).AddTicks(79));
        }
    }
}
