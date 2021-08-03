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

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class GetSkillPostDetailQueryHandler : IRequestHandler<GetSkillPostDetailQuery, SkillPostVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetSkillPostDetailQueryHandler(IAppForSkillsDbContext skillsDbContext, IMapper mapper)
        {
            _context = skillsDbContext;
            _mapper = mapper;
        }

        public async Task<SkillPostVm> Handle(GetSkillPostDetailQuery request, CancellationToken cancellationToken)
        {
            var skillPost = await _context.SkillPosts.Where(s => s.StatusId == 1 && s.Id == request.SkillPostId)
                .Include(r => r.Ratings.Where(r => r.StatusId == 1))
                .FirstOrDefaultAsync(cancellationToken);

            var comments = _context.Comments.Where(c => c.StatusId == 1 && c.SkillPostId == skillPost.Id && c.ParentCommentId == null)
                .Include(l => l.Likes).Include(a => a.AnswersToComment).ThenInclude(l => l.Likes);

            var commentsVm = await comments.ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var skillPostVm = _mapper.Map<SkillPostVm>(skillPost);
            skillPostVm.Comments = commentsVm;
            

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
