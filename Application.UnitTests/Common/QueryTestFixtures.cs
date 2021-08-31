using AppForSkills.Application.Common.Mappings;
using AppForSkills.Persistance;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public AppForSkillsDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public QueryTestFixtures()
        {
            Context = AppForSkillsDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            AppForSkillsDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixtures> { }
}
