using AppForSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppForSkills.Persistance.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.Category).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(500).HasColumnName("Achievement").IsRequired();
        }
    }
}
