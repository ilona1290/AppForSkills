using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
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

namespace AppForSkills.Application.Users.Queries.GetUsersSkills
{
    public class GetUserSkillsQueryHandler : IRequestHandler<GetUserSkillsQuery, SkillPostsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserSkillsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillPostsVm> Handle(GetUserSkillsQuery request, CancellationToken cancellationToken)
        {
            var skillPosts = _context.SkillPosts.Where(s => s.User.Username == request.Username)
                .OrderByDescending(s => s.Created);
            var skillPostDtos = await skillPosts.ProjectTo<SkillPostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var skillPostsVm = new SkillPostsVm
            {
                SkillPosts = skillPostDtos
            };

            return skillPostsVm;
        }
    }
}
