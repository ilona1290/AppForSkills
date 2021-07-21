using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class add_new_rating_to_example_skill_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "SkillId", "SkillPostId", "StatusId", "UserId", "Value" },
                values: new object[] { 2, new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(3889), "SuperAdmin", null, null, null, null, 2, null, 0, 1, 4 });

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 751, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 20, 13, 29, 762, DateTimeKind.Local).AddTicks(151));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 44, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 43, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 35, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "SkillPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 7, 21, 19, 27, 13, 42, DateTimeKind.Local).AddTicks(4477));
        }
    }
}
