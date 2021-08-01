using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .Include(u => u.UserSkills)
                .Include(c => c.UserComments)
                .Include(r => r.GavedRatings)
                .Include(d => d.Discussions)
                .Include(a => a.Achievements)
                .FirstOrDefaultAsync(cancellationToken);

            var userVm = _mapper.Map<UserInformationVm>(user);

            return userVm;
        }
    }
}
