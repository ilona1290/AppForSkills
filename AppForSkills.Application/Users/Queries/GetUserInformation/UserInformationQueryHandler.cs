using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserInformation
{
    public class UserInformationQueryHandler : IRequestHandler<GetUserInformationQuery, UserInformationVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public UserInformationQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserInformationVm> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(d => d.StatusId == 1 && d.Username == request.Username)
                .Include(u => u.UserSkills.Where(s => s.StatusId == 1))
                .Include(c => c.UserComments.Where(s => s.StatusId == 1))
                .Include(r => r.GavedRatings.Where(s => s.StatusId == 1))
                .FirstOrDefaultAsync(cancellationToken);
            var user2 = await _context.Users.Where(d => d.StatusId == 1 && d.Username == request.Username)
                .Include(d => d.Discussions.Where(s => s.StatusId == 1))
                .Include(a => a.Achievements.Where(s => s.StatusId == 1))
                .FirstOrDefaultAsync(cancellationToken);

            var userVm = _mapper.Map<UserInformationVm>(user);
            userVm.Discussions = user2.Discussions.Count;
            userVm.Achievements = user2.Achievements.Count;

            return userVm;
        }
    }
}
