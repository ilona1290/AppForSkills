﻿using AppForSkills.Application.Common.Interfaces;
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
            var comments = _context.Comments.Where(c => c.SkillPostId == request.SkillPostId);
            var ratings = _context.Ratings.Where(r => r.SkillPostId == request.SkillPostId).Select(r => r.Value).ToList();

            var skillPostVm = _mapper.Map<SkillPostVm>(skillPost);
            var commentDtos = await comments.ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

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

            commentDtos = commentDtos.Where(p => p.ParentCommentId == null).ToList();

            int sum = ratings.Sum();
            float average = (float)sum / ratings.Count;

            skillPostVm.Comments = commentDtos;
            skillPostVm.Rating = average;

            return skillPostVm;
        }
    }
}
