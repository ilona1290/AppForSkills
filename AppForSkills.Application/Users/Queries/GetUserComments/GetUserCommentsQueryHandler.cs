using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class GetUserCommentsQueryHandler : IRequestHandler<GetUserCommentsQuery, UserCommentsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserCommentsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserCommentsVm> Handle(GetUserCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _context.Comments.Where(c => c.StatusId == 1 && c.CreatedBy == request.Username).Include(r => r.Likes)
                .OrderByDescending(s => s.Created);

            var commentsDtos = await comments.ProjectTo<UserCommentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var comment in commentsDtos)
            {
                if (comment.ParentCommentId != null)
                {
                    var parentComment = await _context.Comments.Where(s => s.StatusId == 1 && s.Id == comment.ParentCommentId)
                        .FirstOrDefaultAsync(cancellationToken);
                    var parentCommentVm = _mapper.Map<CommentDto>(parentComment);
                    comment.ParentComment = parentCommentVm;
                }
            }

            var commentsVm = new UserCommentsVm
            {
                Comments = commentsDtos
            };

            return commentsVm;
        }
    }
}
