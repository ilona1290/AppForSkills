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
    public class SkillPostConfiguration : IEntityTypeConfiguration<SkillPost>
    {
        public void Configure(EntityTypeBuilder<SkillPost> builder)
        {
            builder.Property(p => p.AddressOfPhotoOrVideo).HasColumnName("Address").IsRequired();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();  
        }
    }
}
