using AppForSkills.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppForSkills.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppForSkillsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppForSkillsDatabase")));
            services.AddScoped<IAppForSkillsDbContext, AppForSkillsDbContext>();
            return services;
        }
    }
}
