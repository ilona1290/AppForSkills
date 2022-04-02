using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Achievements.Queries.GetAchievements
{
    public class GetAchievementsQueryHandler :IRequestHandler<GetAchievementsQuery, AchievementsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetAchievementsQueryHandler(IAppForSkillsDbContext skillsDbContext, IMapper mapper)
        {
            _context = skillsDbContext;
            _mapper = mapper;
        }

        public async Task<AchievementsVm> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
        {
            var achievements = _context.Achievements.Where(a => a.StatusId == 1);
            var achievementsDtos = await achievements.ProjectTo<AchievementDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var achievementsVm = new AchievementsVm
            {
                Achievements = achievementsDtos
            };

            return achievementsVm;
        }
    }
}
