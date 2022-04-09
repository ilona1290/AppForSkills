using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Commands.GiveLike
{
    public class GiveLikeCommandHandler : IRequestHandler<GiveLikeCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GiveLikeCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(GiveLikeCommand request, CancellationToken cancellationToken)
        {
            var like = _mapper.Map<Like>(request);
            var user = await _context.Users.Where(u => u.StatusId == 1 && u.Username == request.User)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            like.Avatar = user.Avatar;
            _context.Likes.Add(like);

            var notification = new Notification()
            {
                FromWhoId = user.Id,
                When = DateTime.Now
            };

            if (request.CommentId != null)
            {
                var comment = await _context.Comments.Where(c => c.Id == request.CommentId).FirstOrDefaultAsync(cancellationToken);
                notification.ToWhoId = comment.UserId;
                notification.Message = "Lubi Twój komentarz: " + comment.CommentText;
            }
            else if(request.DiscussionId != null)
            {
                var discussion = await _context.Discussions.Where(d => d.Id == request.DiscussionId).FirstOrDefaultAsync(cancellationToken);
                var userDisc = await _context.Users.Where(u => u.StatusId == 1 && u.Username == discussion.CreatedBy)
                    .FirstOrDefaultAsync(cancellationToken);
                notification.ToWhoId = userDisc.Id;
                notification.Message = "Lubi Twoją dyskusję: " + discussion.FirstPost;
            }
            else if(request.PostInDiscussionId != null)
            {
                var postInDiscussion = await _context.PostsInDiscussion.Where(p => p.Id == request.PostInDiscussionId).FirstOrDefaultAsync(cancellationToken);
                notification.ToWhoId = postInDiscussion.UserId;
                notification.Message = "Lubi Twój post w dyskusji: " + postInDiscussion.PostText;
            }

            if(notification.FromWhoId != notification.ToWhoId)
            {
                _context.Notifications.Add(notification);
            }
            
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
