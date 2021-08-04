using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class deleted_one_to_many_relation_in_the_same_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostsInDiscussion",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_UserId",
                table: "PostsInDiscussion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsInDiscussion_Users_UserId",
                table: "PostsInDiscussion",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsInDiscussion_Users_UserId",
                table: "PostsInDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_PostsInDiscussion_UserId",
                table: "PostsInDiscussion");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostsInDiscussion");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 804, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 804, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 805, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 805, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 806, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 804, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 804, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 795, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 3, 15, 17, 0, 802, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion",
                column: "ParentPostId",
                principalTable: "PostsInDiscussion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
