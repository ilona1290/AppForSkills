using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class CreateNotificationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWhoId = table.Column<int>(type: "int", nullable: true),
                    ToWhoId = table.Column<int>(type: "int", nullable: true),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_FromWhoId",
                        column: x => x.FromWhoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ToWhoId",
                        column: x => x.ToWhoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 394, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 19, 25, 58, 390, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RecentLoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 4, 4, 19, 25, 58, 395, DateTimeKind.Local).AddTicks(755), new DateTime(2022, 4, 4, 19, 25, 58, 395, DateTimeKind.Local).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RecentLoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 4, 4, 19, 25, 58, 395, DateTimeKind.Local).AddTicks(974), new DateTime(2022, 4, 4, 19, 25, 58, 395, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FromWhoId",
                table: "Notifications",
                column: "FromWhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ToWhoId",
                table: "Notifications",
                column: "ToWhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "PostsInDiscussion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 575, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 2, 23, 31, 59, 568, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RecentLoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 23, 31, 59, 576, DateTimeKind.Local).AddTicks(480), new DateTime(2022, 4, 2, 23, 31, 59, 576, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RecentLoginDate", "RegistrationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 23, 31, 59, 576, DateTimeKind.Local).AddTicks(681), new DateTime(2022, 4, 2, 23, 31, 59, 576, DateTimeKind.Local).AddTicks(675) });
        }
    }
}
