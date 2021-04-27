using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Persistance
{
    public class AppForSkillsDbContext : DbContext
    {
        public AppForSkillsDbContext(DbContextOptions<AppForSkillsDbContext> options) : base(options)
        {

        }
    }
}
