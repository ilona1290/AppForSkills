using Microsoft.EntityFrameworkCore;

namespace AppForSkills.Persistance
{
    class AppForSkillsDbContextFactory : DesignTimeDbContextFactoryBase<AppForSkillsDbContext>
    {
        protected override AppForSkillsDbContext CreateNewInstance(DbContextOptions<AppForSkillsDbContext> options)
        {
            return new AppForSkillsDbContext(options);
        }
    }
}
