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
                .Include(c => c.Comments.Where(r => r.StatusId == 1)).ThenInclude(a => a.AnswersToComment)
                .ThenInclude(c => c.Likes)
                .Include(r => r.Ratings.Where(r => r.StatusId == 1))
                .FirstOrDefaultAsync(cancellationToken);
            /*var comments = _context.Comments.Where(c => c.SkillPostId == request.SkillPostId);
            var ratings = _context.Ratings.Where(r => r.SkillPostId == request.SkillPostId).Select(r => r.Value).ToList();
            */
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
            
            
            /*var commentDtos = await comments.ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            int index;
            int length = commentDtos.Count;
            for (int i = length - 1; i > 0; i--)
            {
                if (commentDtos[i].ParentCommentId != null)
                {
                    index = (int)commentDtos[i].ParentCommentId - 1;
                    commentDtos[index].AnswersToComment.Add(commentDtos[i]);
                }
            }

            commentDtos = commentDtos.Where(p => p.ParentCommentId == null).ToList();*/

            

            /*skillPostVm.Comments = commentDtos;
            skillPostVm.Rating = average;*/

            return skillPostVm;
        }
    }
}
