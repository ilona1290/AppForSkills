using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Domain.Common;
using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Persistance
{
    public class AppForSkillsDbContext : DbContext, IAppForSkillsDbContext
    {
        private readonly IDateTime _dateTime;
        public AppForSkillsDbContext(DbContextOptions<AppForSkillsDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public AppForSkillsDbContext(DbContextOptions<AppForSkillsDbContext> options) : base(options)
        {
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PostInDiscussion> PostsInDiscussion { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SkillPost> SkillPosts { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
