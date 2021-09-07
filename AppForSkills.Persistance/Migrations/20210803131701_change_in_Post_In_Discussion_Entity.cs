using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppForSkills.Persistance.Migrations
{
    public partial class change_in_Post_In_Discussion_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_PostInDiscussionId",
                table: "PostsInDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_PostsInDiscussion_PostInDiscussionId",
                table: "PostsInDiscussion");

            migrationBuilder.DropColumn(
                name: "PostInDiscussionId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion",
                column: "ParentPostId",
                principalTable: "PostsInDiscussion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_PostsInDiscussion_ParentPostId",
                table: "PostsInDiscussion");

            migrationBuilder.AddColumn<int>(
                name: "PostInDiscussionId",
                table: "PostsInDiscussion",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_PostInDiscussionId",
                table: "PostsInDiscussion",
                column: "PostInDiscussionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsInDiscussion_PostsInDiscussion_PostInDiscussionId",
                table: "PostsInDiscussion",
                column: "PostInDiscussionId",
                principalTable: "PostsInDiscussion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
