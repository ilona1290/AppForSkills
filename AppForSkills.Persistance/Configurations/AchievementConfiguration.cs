using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppForSkills.Persistance.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).HasColumnName("Achievement").IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
        }
    }
}
