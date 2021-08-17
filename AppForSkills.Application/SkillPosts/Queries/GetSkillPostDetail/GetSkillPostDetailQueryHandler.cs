using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
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

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class GetSkillPostDetailQueryHandler : IRequestHandler<GetSkillPostDetailQuery, SkillPostVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        public GetSkillPostDetailQueryHandler(IAppForSkillsDbContext skillsDbContext, IMapper mapper, ICurrentUserService userService)
        {
            _context = skillsDbContext;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<SkillPostVm> Handle(GetSkillPostDetailQuery request, CancellationToken cancellationToken)
        {
            var skillPost = await _context.SkillPosts.Where(s => s.StatusId == 1 && s.Id == request.SkillPostId)
                .Include(p => p.Comments.Where(d => d.StatusId == 1)).ThenInclude(l => l.Likes)
                .Include(r => r.Ratings.Where(r => r.StatusId == 1))
                .FirstOrDefaultAsync(cancellationToken);

            if (skillPost == null)
            {
                throw new WrongIDException("Skill Post with gaved id could not display, because not exists in database. " +
                    "Give another id.");
            }

            var skillPostVm = _mapper.Map<SkillPostVm>(skillPost);
            
            if (skillPost.Ratings.Count > 0)
            {
                int sum = skillPost.Ratings.Select(r => r.Value).Sum();
                float average = (float)sum / skillPost.Ratings.Count;
                skillPostVm.Rating = average;
            }
            else
            {
                skillPostVm.Rating = 0;
            }

            skillPost.Views++;
            await _context.SaveChangesAsync(cancellationToken);
            skillPostVm.Views++;

            return skillPostVm;
        }
    }
}
