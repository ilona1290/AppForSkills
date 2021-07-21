using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class Small_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_SkillPosts_SkillPostId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "SkillPostId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 24, 10, 39, DateTimeKind.Local).AddTicks(4218));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_SkillPosts_SkillPostId",
                table: "Ratings",
                column: "SkillPostId",
                principalTable: "SkillPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_SkillPosts_SkillPostId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "SkillPostId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 853, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 853, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 854, DateTimeKind.Local).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 853, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 853, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 845, DateTimeKind.Local).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 22, 21, 37, 852, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_SkillPosts_SkillPostId",
                table: "Ratings",
                column: "SkillPostId",
                principalTable: "SkillPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
