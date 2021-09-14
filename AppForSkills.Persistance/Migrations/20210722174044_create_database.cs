using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppForSkills.Persistance.Migrations
{
    public partial class create_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achievement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstPost = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecentLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostsInDiscussion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DiscussionId = table.Column<int>(type: "int", nullable: false),
                    ParentPostId = table.Column<int>(type: "int", nullable: true),
                    Reported = table.Column<bool>(type: "bit", nullable: false),
                    PostInDiscussionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsInDiscussion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsInDiscussion_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsInDiscussion_PostsInDiscussion_PostInDiscussionId",
                        column: x => x.PostInDiscussionId,
                        principalTable: "PostsInDiscussion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AchievementUser",
                columns: table => new
                {
                    AchievementsId = table.Column<int>(type: "int", nullable: false),
                    UsersWithAchivementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementUser", x => new { x.AchievementsId, x.UsersWithAchivementId });
                    table.ForeignKey(
                        name: "FK_AchievementUser_Achievements_AchievementsId",
                        column: x => x.AchievementsId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AchievementUser_Users_UsersWithAchivementId",
                        column: x => x.UsersWithAchivementId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscussionUser",
                columns: table => new
                {
                    DiscussionsId = table.Column<int>(type: "int", nullable: false),
                    UsersInDiscussionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionUser", x => new { x.DiscussionsId, x.UsersInDiscussionId });
                    table.ForeignKey(
                        name: "FK_DiscussionUser_Discussions_DiscussionsId",
                        column: x => x.DiscussionsId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionUser_Users_UsersInDiscussionId",
                        column: x => x.UsersInDiscussionId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SkillPostId = table.Column<int>(type: "int", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_SkillPosts_SkillPostId",
                        column: x => x.SkillPostId,
                        principalTable: "SkillPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SkillPostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_SkillPosts_SkillPostId",
                        column: x => x.SkillPostId,
                        principalTable: "SkillPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostInDiscussionId = table.Column<int>(type: "int", nullable: true),
                    DiscussionId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_PostsInDiscussion_PostInDiscussionId",
                        column: x => x.PostInDiscussionId,
                        principalTable: "PostsInDiscussion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "Achievement" },
                values: new object[,]
                {
                    { 1, "Dodano pierwszy post.", "Świerzak" },
                    { 2, "Rozpoczęto pierwszą dyskusję.", "Początkujący mówca" },
                    { 3, "Dodano pierwszy post do dyskusji.", "Pierwsze udzielenie się" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Created", "CreatedBy", "FirstPost", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(5040), "SuperAdmin", "Cześć. W tej części aplikacji będziesz mógł rozpoczynać dyskusje, bądź udzielać się już w istniejących.", null, null, null, null, 1 },
                    { 2, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(5394), "Podróżnik", "Jaki kraj chcielibyście odwiedzić?", null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "RecentLoginDate", "RegistrationDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperAdmin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podrożnik" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turysta12" }
                });

            migrationBuilder.InsertData(
                table: "DiscussionUser",
                columns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 4, null, 1, null, "Podróżnik" },
                    { 5, null, 2, null, "Turysta12" },
                    { 6, null, 2, null, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentPostId", "PostInDiscussionId", "PostText", "Reported", "StatusId" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6936), "Podróżnik", 1, null, null, null, null, null, null, "Jasne.", false, 1 },
                    { 1, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6589), "Turysta12", 2, null, null, null, null, null, null, "Australia", false, 1 },
                    { 2, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6603), "Podróżnik", 2, null, null, null, null, 1, null, "Dlaczego?", false, 1 },
                    { 3, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6926), "Turysta12", 2, null, null, null, null, 2, null, "Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).", false, 1 },
                    { 5, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6939), "SuperAdmin", 2, null, null, null, null, null, null, "Włochy", false, 1 },
                    { 6, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(6942), "SuperAdmin", 2, null, null, null, null, 1, null, "Możesz rozwinąć?", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "SkillPosts",
                columns: new[] { "Id", "Address", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Title", "UserId", "Views" },
                values: new object[,]
                {
                    { 1, "images/firstPost.jpg", new DateTime(2021, 7, 22, 19, 40, 43, 320, DateTimeKind.Local).AddTicks(3871), null, "Cześć. W tej części aplikacji będziesz mógł zaprezentować pozostałym użytkownikom swoje umiejętności/talenty w formie zdjęcia, bądź filmiku. Dodać do niego tytuł i opis. Każdy użytkownik, może oceniać, komentować dany post. Baw się dobrze!", null, null, null, null, 1, "Start", 1, 0 },
                    { 2, "images/Eiffel_Tower.jpg", new DateTime(2021, 7, 22, 19, 40, 43, 328, DateTimeKind.Local).AddTicks(6385), "Podrożnik", "Cześć. Autorskie zdjęcie wieży Eiffla", null, null, null, null, 2, "Wieża Eiffla", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "CommentText", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "ParentCommentId", "SkillPostId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Wow! Super zdjęcie.", new DateTime(2021, 7, 22, 19, 40, 43, 329, DateTimeKind.Local).AddTicks(7819), "Turysta12", null, null, null, null, null, 2, 0, 3 },
                    { 2, null, "Dzięki.", new DateTime(2021, 7, 22, 19, 40, 43, 329, DateTimeKind.Local).AddTicks(8630), "Podrożnik", null, null, null, null, 1, 2, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 7, null, null, 1, "Podróżnik" },
                    { 8, null, null, 3, "Podróżnik" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "SkillPostId", "StatusId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 22, 19, 40, 43, 329, DateTimeKind.Local).AddTicks(9543), "Turysta12", null, null, null, null, 2, 0, 3, 5 },
                    { 2, new DateTime(2021, 7, 22, 19, 40, 43, 330, DateTimeKind.Local).AddTicks(419), "SuperAdmin", null, null, null, null, 2, 0, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 1, 1, null, null, "Podróżnik" });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 3, 1, null, null, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 2, 2, null, null, "Turysta12" });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_UsersWithAchivementId",
                table: "AchievementUser",
                column: "UsersWithAchivementId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SkillPostId",
                table: "Comments",
                column: "SkillPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionUser_UsersInDiscussionId",
                table: "DiscussionUser",
                column: "UsersInDiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_DiscussionId",
                table: "Likes",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostInDiscussionId",
                table: "Likes",
                column: "PostInDiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_DiscussionId",
                table: "PostsInDiscussion",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_PostInDiscussionId",
                table: "PostsInDiscussion",
                column: "PostInDiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SkillPostId",
                table: "Ratings",
                column: "SkillPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillPosts_UserId",
                table: "SkillPosts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementUser");

            migrationBuilder.DropTable(
                name: "DiscussionUser");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostsInDiscussion");

            migrationBuilder.DropTable(
                name: "SkillPosts");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
