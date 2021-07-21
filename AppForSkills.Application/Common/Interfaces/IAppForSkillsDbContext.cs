using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Common.Interfaces
{
    public interface IAppForSkillsDbContext
    {
        DbSet<Achievement> Achievements { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Discussion> Discussions { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<PostInDiscussion> PostsInDiscussion { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<SkillPost> SkillPosts { get; set; }
        DbSet<UserInformation> UserInformations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
