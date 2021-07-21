﻿// <auto-generated />
using System;
using AppForSkills.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppForSkills.Persistance.Migrations
{
    [DbContext(typeof(AppForSkillsDbContext))]
    partial class AppForSkillsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AchievementUserInformation", b =>
                {
                    b.Property<int>("AchievementsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersWithAchivementId")
                        .HasColumnType("int");

                    b.HasKey("AchievementsId", "UsersWithAchivementId");

                    b.HasIndex("UsersWithAchivementId");

                    b.ToTable("AchievementUserInformation");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Achievement");

                    b.HasKey("Id");

                    b.ToTable("Achievements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dodano pierwszy post.",
                            Name = "Świerzak"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rozpoczęto pierwszą dyskusję.",
                            Name = "Początkujący mówca"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Dodano pierwszy post do dyskusji.",
                            Name = "Pierwsze udzielenie się"
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("SkillPostId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("SkillPostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentText = "Wow! Super zdjęcie.",
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(1508),
                            CreatedBy = "Turysta12",
                            SkillPostId = 2,
                            StatusId = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            CommentText = "Dzięki.",
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(2174),
                            CreatedBy = "Podrożnik",
                            ParentCommentId = 1,
                            SkillPostId = 2,
                            StatusId = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Discussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPost")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discussions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(7081),
                            FirstPost = "Cześć. W tej części aplikacji będziesz mógł rozpoczynać dyskusje, bądź udzielać się już w istniejących.",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<int?>("PostInDiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("PostInDiscussionId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentId = 1,
                            User = "Podróżnik"
                        },
                        new
                        {
                            Id = 2,
                            CommentId = 2,
                            User = "Turysta12"
                        },
                        new
                        {
                            Id = 3,
                            CommentId = 1,
                            User = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.PostInDiscussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentPostId")
                        .HasColumnType("int");

                    b.Property<int?>("PostInDiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("PostText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Reported")
                        .HasColumnType("bit");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("PostInDiscussionId");

                    b.ToTable("PostsInDiscussion");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillPostId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillPostId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(3621),
                            CreatedBy = "Turysta12",
                            SkillId = 2,
                            StatusId = 0,
                            UserId = 3,
                            Value = 5
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 763, DateTimeKind.Local).AddTicks(3889),
                            CreatedBy = "SuperAdmin",
                            SkillId = 2,
                            StatusId = 0,
                            UserId = 1,
                            Value = 4
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.SkillPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressOfPhotoOrVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SkillPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressOfPhotoOrVideo = "images/firstPost.jpg",
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 751, DateTimeKind.Local).AddTicks(3365),
                            Description = "Cześć. W tej części aplikacji będziesz mógł zaprezentować pozostałym użytkownikom swoje umiejętności/talenty w formie zdjęcia, bądź filmiku. Dodać do niego tytuł i opis. Każdy użytkownik, może oceniać, komentować dany post. Baw się dobrze!",
                            StatusId = 1,
                            Title = "Start",
                            UserId = 1,
                            Views = 0
                        },
                        new
                        {
                            Id = 2,
                            AddressOfPhotoOrVideo = "images/Eiffel_Tower.jpg",
                            Created = new DateTime(2021, 7, 21, 20, 13, 29, 762, DateTimeKind.Local).AddTicks(151),
                            CreatedBy = "Podrożnik",
                            Description = "Cześć. Autorskie zdjęcie wieży Eiffla",
                            StatusId = 2,
                            Title = "Wieża Eiffla",
                            UserId = 2,
                            Views = 0
                        });
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.UserInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RecentLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserInformations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RecentLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "SuperAdmin"
                        },
                        new
                        {
                            Id = 2,
                            RecentLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "Podrożnik"
                        },
                        new
                        {
                            Id = 3,
                            RecentLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "Turysta12"
                        });
                });

            modelBuilder.Entity("DiscussionUserInformation", b =>
                {
                    b.Property<int>("DiscussionsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersInDiscussionId")
                        .HasColumnType("int");

                    b.HasKey("DiscussionsId", "UsersInDiscussionId");

                    b.HasIndex("UsersInDiscussionId");

                    b.ToTable("DiscussionUserInformation");
                });

            modelBuilder.Entity("AchievementUserInformation", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.Achievement", null)
                        .WithMany()
                        .HasForeignKey("AchievementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppForSkills.Domain.Entities.UserInformation", null)
                        .WithMany()
                        .HasForeignKey("UsersWithAchivementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Comment", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.Comment", null)
                        .WithMany("AnswersToComment")
                        .HasForeignKey("CommentId");

                    b.HasOne("AppForSkills.Domain.Entities.SkillPost", "SkillPost")
                        .WithMany("Comments")
                        .HasForeignKey("SkillPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppForSkills.Domain.Entities.UserInformation", "User")
                        .WithMany("UserComments")
                        .HasForeignKey("UserId");

                    b.Navigation("SkillPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Like", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.Comment", "Commment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId");

                    b.HasOne("AppForSkills.Domain.Entities.Discussion", "Discussion")
                        .WithMany("Likes")
                        .HasForeignKey("DiscussionId");

                    b.HasOne("AppForSkills.Domain.Entities.PostInDiscussion", "PostInDiscussion")
                        .WithMany("Likes")
                        .HasForeignKey("PostInDiscussionId");

                    b.Navigation("Commment");

                    b.Navigation("Discussion");

                    b.Navigation("PostInDiscussion");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.PostInDiscussion", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.Discussion", "Discussion")
                        .WithMany("PostsInDiscussion")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppForSkills.Domain.Entities.PostInDiscussion", null)
                        .WithMany("AnswersToPost")
                        .HasForeignKey("PostInDiscussionId");

                    b.Navigation("Discussion");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Rating", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.SkillPost", "SkillPost")
                        .WithMany("Ratings")
                        .HasForeignKey("SkillPostId");

                    b.HasOne("AppForSkills.Domain.Entities.UserInformation", "User")
                        .WithMany("GavedRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.SkillPost", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.UserInformation", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscussionUserInformation", b =>
                {
                    b.HasOne("AppForSkills.Domain.Entities.Discussion", null)
                        .WithMany()
                        .HasForeignKey("DiscussionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppForSkills.Domain.Entities.UserInformation", null)
                        .WithMany()
                        .HasForeignKey("UsersInDiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Comment", b =>
                {
                    b.Navigation("AnswersToComment");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.Discussion", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("PostsInDiscussion");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.PostInDiscussion", b =>
                {
                    b.Navigation("AnswersToPost");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.SkillPost", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("AppForSkills.Domain.Entities.UserInformation", b =>
                {
                    b.Navigation("GavedRatings");

                    b.Navigation("UserComments");

                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
