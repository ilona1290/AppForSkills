﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppForSkills.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Achievement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecentLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "PostsInDiscussion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DiscussionId = table.Column<int>(type: "int", nullable: false),
                    MainParentPostId = table.Column<int>(type: "int", nullable: true),
                    ParentPostId = table.Column<int>(type: "int", nullable: true),
                    Reported = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PostsInDiscussion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsInDiscussion_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsInDiscussion_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.PrimaryKey("PK_SkillPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SkillPostId = table.Column<int>(type: "int", nullable: false),
                    MainParentCommentId = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Comments", x => x.Id);
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
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostInDiscussionId = table.Column<int>(type: "int", nullable: true),
                    DiscussionId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true)
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
                columns: new[] { "Id", "Amount", "Category", "Description", "Logo", "Achievement", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, "Skills", "Dodano pierwszy SkillPost", "https://appforskills1.blob.core.windows.net/achivement-logos/skill1.png", "Początkujący Skiller", 1 },
                    { 25, 200, "Posty w dyskusjach", "Udzielono się 200 razy w dyskusjach", "https://appforskills1.blob.core.windows.net/achivement-logos/pwd5.png", "200 postów już gotowych, milion kolejnych w drodze...", 1 },
                    { 24, 50, "Posty w dyskusjach", "Udzielono się 50 razy w dyskusjach", "https://appforskills1.blob.core.windows.net/achivement-logos/pwd4.png", "Nie zwrócimy Ci czasu jaki spędziłeś na pisaniu tych postów", 1 },
                    { 23, 25, "Posty w dyskusjach", "Udzielono się 25 razy w dyskusjach", "https://appforskills1.blob.core.windows.net/achivement-logos/pwd3.png", "Prowadzący Talk-Show", 1 },
                    { 22, 15, "Posty w dyskusjach", "Udzielono się 15 razy w dyskusjach", "https://appforskills1.blob.core.windows.net/achivement-logos/pwd2.png", "Mam coś więcej do powiedzenia niż tylko ALE", 1 },
                    { 21, 1, "Posty w dyskusjach", "Udzielono się raz w dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/pwd1.png", "Ja tu tylko dyskutuję", 1 },
                    { 20, 100, "Dyskusje", "Dołączono do 100 dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/dis5.png", "Crushin' discussion", 1 },
                    { 19, 50, "Dyskusje", "Dołączono do 50 dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/dis4.png", "Dyskutant-Alfa", 1 },
                    { 18, 25, "Dyskusje", "Dołączono do 25 dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/dis3.png", "Naczelny Gaduła", 1 },
                    { 17, 5, "Dyskusje", "Dołączono do 5 dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/dis2.png", "Zawsze musi być jakieś ALE", 1 },
                    { 16, 1, "Dyskusje", "Dołączono do pierwszej dyskusji", "https://appforskills1.blob.core.windows.net/achivement-logos/dis1.png", "Chcę coś oznajmić", 1 },
                    { 15, 50, "Oceny", "Oceniono 50 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/rat5.png", "Dał/Dała tyle gwiazdek, że może nakręcić własny teledysk Shooting Stars", 1 },
                    { 14, 25, "Oceny", "Oceniono 25 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/rat4.png", "Mamo, możemy mieć własną konstelacje w domu?", 1 },
                    { 12, 5, "Oceny", "Oceniono 5 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/rat2.png", "Taniec z gwiazdami", 1 },
                    { 11, 1, "Oceny", "Oceniono pierwszy SkillPost", "https://appforskills1.blob.core.windows.net/achivement-logos/rat1.png", "Dam Ci gwiazdkę z nieba", 1 },
                    { 10, 125, "Komentarze", "Dodano 125 Komentarzy", "https://appforskills1.blob.core.windows.net/achivement-logos/kom5.png", "Mógłby/Mogłaby napisać książkę, ale pisze komentarze", 1 },
                    { 9, 100, "Komentarze", "Dodano 100 Komentarzy", "https://appforskills1.blob.core.windows.net/achivement-logos/kom4.png", "Imperator-komentator", 1 },
                    { 8, 50, "Komentarze", "Dodano 50 Komentarzy", "https://appforskills1.blob.core.windows.net/achivement-logos/kom3.png", "Komentator-niekoniecznie-sportowy", 1 },
                    { 7, 25, "Komentarze", "Dodano 25 Komentarzy", "https://appforskills1.blob.core.windows.net/achivement-logos/kom2.png", "Buszujący w komentarzach", 1 },
                    { 6, 5, "Komentarze", "Dodano 5 Komentarzy", "https://appforskills1.blob.core.windows.net/achivement-logos/kom1.png", "Coś tam sobie pomamrocze", 1 },
                    { 5, 25, "Skills", "Dodano 25 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/skill5.png", "SkillGod", 1 },
                    { 4, 15, "Skills", "Dodano 15 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/skill4.png", "Co za utalentowana bestia", 1 },
                    { 3, 10, "Skills", "Dodano 10 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/skill3.png", "SkillMaster", 1 },
                    { 2, 5, "Skills", "Dodano 5 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/skill2.png", "Szał umiejętności", 1 },
                    { 13, 15, "Oceny", "Oceniono 15 SkillPost'ów", "https://appforskills1.blob.core.windows.net/achivement-logos/rat3.png", "Mówcie mi StarLord", 1 }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Created", "CreatedBy", "FirstPost", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { 1, new DateTime(2022, 4, 10, 22, 24, 36, 822, DateTimeKind.Local).AddTicks(7967), "Podróżnik", "Jaki kraj chcielibyście odwiedzić?", null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "RecentLoginDate", "RegistrationDate", "StatusId", "Username" },
                values: new object[,]
                {
                    { 1, "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg", new DateTime(2022, 4, 10, 22, 24, 36, 823, DateTimeKind.Local).AddTicks(9365), new DateTime(2022, 4, 10, 22, 24, 36, 823, DateTimeKind.Local).AddTicks(8828), 1, "Podróżnik" },
                    { 2, "", new DateTime(2022, 4, 10, 22, 24, 36, 824, DateTimeKind.Local).AddTicks(470), new DateTime(2022, 4, 10, 22, 24, 36, 824, DateTimeKind.Local).AddTicks(448), 1, "Turysta12" }
                });

            migrationBuilder.InsertData(
                table: "AchievementUser",
                columns: new[] { "AchievementsId", "UsersWithAchivementId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 16, 1 },
                    { 11, 2 },
                    { 16, 2 }
                });

            migrationBuilder.InsertData(
                table: "DiscussionUser",
                columns: new[] { "DiscussionsId", "UsersInDiscussionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "Avatar", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 3, "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg", null, 1, null, "Podróżnik" },
                    { 4, "", null, 1, null, "Turysta12" }
                });

            migrationBuilder.InsertData(
                table: "PostsInDiscussion",
                columns: new[] { "Id", "Created", "CreatedBy", "DiscussionId", "Inactivated", "InactivatedBy", "MainParentPostId", "Modified", "ModifiedBy", "ParentPostId", "PostText", "Reported", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 4, 10, 22, 24, 36, 823, DateTimeKind.Local).AddTicks(908), "Podróżnik", 1, null, null, 1, null, null, 1, "Dlaczego?", false, 1, 1 },
                    { 1, new DateTime(2022, 4, 10, 22, 24, 36, 823, DateTimeKind.Local).AddTicks(385), "Turysta12", 1, null, null, null, null, null, null, "Australia", false, 1, 2 },
                    { 3, new DateTime(2022, 4, 10, 22, 24, 36, 823, DateTimeKind.Local).AddTicks(1800), "Turysta12", 1, null, null, 1, null, null, 2, "@Podróżnik Ponieważ zawsze podróżowałem po Europie i chciałbym czegoś nowego :).", false, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "SkillPosts",
                columns: new[] { "Id", "Address", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Title", "UserId" },
                values: new object[] { 1, "https://appforskills1.blob.core.windows.net/upload-container/Eiffel_Tower.jpg", new DateTime(2022, 4, 10, 22, 24, 36, 811, DateTimeKind.Local).AddTicks(8358), "Podróżnik", "Cześć. Autorskie zdjęcie wieży Eiffla", null, null, null, null, 1, "Wieża Eiffla", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "MainParentCommentId", "Modified", "ModifiedBy", "ParentCommentId", "SkillPostId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, "Wow! Super zdjęcie.", new DateTime(2022, 4, 10, 22, 24, 36, 821, DateTimeKind.Local).AddTicks(6034), "Turysta12", null, null, null, null, null, null, 1, 1, 2 },
                    { 2, "Dzięki.", new DateTime(2022, 4, 10, 22, 24, 36, 821, DateTimeKind.Local).AddTicks(7696), "Podróżnik", null, null, 1, null, null, 1, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "Avatar", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[,]
                {
                    { 5, "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg", null, null, 1, "Podróżnik" },
                    { 6, "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg", null, null, 3, "Podróżnik" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "SkillPostId", "StatusId", "UserId", "Value" },
                values: new object[] { 1, new DateTime(2022, 4, 10, 22, 24, 36, 822, DateTimeKind.Local).AddTicks(213), "Turysta12", null, null, null, null, 1, 1, 2, 5 });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "Avatar", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 1, "https://appforskills1.blob.core.windows.net/avatars/piesek.jpg", 1, null, null, "Podróżnik" });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "Avatar", "CommentId", "DiscussionId", "PostInDiscussionId", "User" },
                values: new object[] { 2, "", 2, null, null, "Turysta12" });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_UsersWithAchivementId",
                table: "AchievementUser",
                column: "UsersWithAchivementId");

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
                name: "IX_Notifications_FromWhoId",
                table: "Notifications",
                column: "FromWhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ToWhoId",
                table: "Notifications",
                column: "ToWhoId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_DiscussionId",
                table: "PostsInDiscussion",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsInDiscussion_UserId",
                table: "PostsInDiscussion",
                column: "UserId");

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
                name: "Notifications");

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
