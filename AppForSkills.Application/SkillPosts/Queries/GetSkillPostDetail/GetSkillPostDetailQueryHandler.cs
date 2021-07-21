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
            var skillPost = await _context.SkillPosts.Where(s => s.Id == request.SkillPostId).FirstOrDefaultAsync(cancellationToken);
            var comments = _context.Comments.Where(c => c.SkillPostId == request.SkillPostId && c.ParentCommentId == null);
            var answerComments = _context.Comments.Where(c => c.ParentCommentId != null);
            var ratings = _context.Ratings.Where(r => r.SkillId == request.SkillPostId).Select(r => r.Value).ToList();

            var skillPostVm = _mapper.Map<SkillPostVm>(skillPost);
            var commentDtos = await comments.ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var answerCommentDtos = await answerComments.ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            
            
            foreach (var answerComment in answerCommentDtos)
            {
                foreach (var comment in commentDtos)
                {
                    if(comment.Id == answerComment.ParentCommentId)
                    {
                        comment.AnswersToComment.Add(answerComment);
                    }
                }
            }

            int sum = ratings.Sum();
            float average = (float)sum / ratings.Count;

            skillPostVm.Comments = commentDtos;
            skillPostVm.Rating = average;

            return skillPostVm;
        }
    }
}
