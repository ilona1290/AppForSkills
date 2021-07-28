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

namespace AppForSkills.Application.Users.Queries.GetUserAchievements
{
    public class GetUserAchievementsQueryHandler : IRequestHandler<GetUserAchievementsQuery, AchievementsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserAchievementsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AchievementsVm> Handle(GetUserAchievementsQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            var achievements = _context.Achievements.Where(d => d.UsersWithAchivement.Contains(user));

            var achievementDtos = await achievements.ProjectTo<AchievementDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var achievementsVm = new AchievementsVm
            {
                Achievements = achievementDtos
            };

            return achievementsVm;
        }
    }
}
