using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Persistance.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasMany(a => a.AnswersToComment).WithOne(p => p.ParentComment).HasForeignKey(s => s.ParentCommentId);
            builder.Property(p => p.CommentText).HasMaxLength(500).IsRequired();
        }
    }
}
