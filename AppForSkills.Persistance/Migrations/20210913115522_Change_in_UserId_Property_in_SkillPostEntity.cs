using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppForSkills.Persistance.Migrations
{
    public partial class Change_in_UserId_Property_in_SkillPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillPosts_Users_UserId",
                table: "SkillPosts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 14, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 14, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 15, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 14, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 14, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 20, 997, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 13, 13, 55, 21, 12, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.AddForeignKey(
                name: "FK_SkillPosts_Users_UserId",
                table: "SkillPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillPosts_Users_UserId",
                table: "SkillPosts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillPosts",
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
                value: new DateTime(2021, 8, 4, 16, 46, 48, 461, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 461, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 461, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 462, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 448, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 4, 16, 46, 48, 460, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.AddForeignKey(
                name: "FK_SkillPosts_Users_UserId",
                table: "SkillPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
