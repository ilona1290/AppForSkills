using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppForSkills.Persistance.Configurations
{
    public class PostInDiscussionConfiguration : IEntityTypeConfiguration<PostInDiscussion>
    {
        public void Configure(EntityTypeBuilder<PostInDiscussion> builder)
        {
            builder.Property(p => p.PostText).HasMaxLength(500).IsRequired();
        }
    }
}
