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

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class GetUserCommentsQueryHandler : IRequestHandler<GetUserCommentsQuery, CommentsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserCommentsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentsVm> Handle(GetUserCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _context.Comments.Where(c => c.StatusId == 1 && c.User.Username == request.Username)
                .OrderByDescending(c => c.Created);

            var commentsDtos = await comments.ProjectTo<UserCommentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var comment in commentsDtos)
            {
                if(comment.ParentCommentId != null)
                {
                    comment.ParentCommentText = _context.Comments.FirstOrDefault(c => c.Id == comment.ParentCommentId)
                        .CommentText;
                }
            }

            var commentsVm = new CommentsVm
            {
                Comments = commentsDtos
            };

            return commentsVm;
        }
    }
}
