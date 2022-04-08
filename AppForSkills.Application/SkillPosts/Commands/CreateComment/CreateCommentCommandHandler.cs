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

namespace AppForSkills.Application.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);

            var skillPost = _context.SkillPosts.Where(u => u.StatusId == 1 && u.Id == request.SkillPostId)
                .FirstOrDefault();

            if (skillPost == null)
            {
                throw new WrongIDException("SkillPost not exists. Wrong Id");
            }

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == comment.CreatedBy)
                .Include(u => u.Achievements)
                .FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            var notification = new Notification()
            {
                FromWhoId = user.Id,
                When = DateTime.Now
            };

            if (comment.ParentCommentId == null)
            {
                notification.ToWhoId = skillPost.UserId;
                notification.Message = "Skomentował(a) Twój SkillPost \"" + skillPost.Title + "\": " +
                    comment.CommentText;
            }
            else
            {
                var parentComment = _context.Comments.Where(c => c.Id == comment.ParentCommentId).FirstOrDefault();
                notification.ToWhoId = parentComment.UserId;
                notification.Message = "Odpowiedział(a) na Twój komentarz \"" + parentComment.CommentText + "\": " +
                    comment.CommentText;
            }

            if (notification.FromWhoId != notification.ToWhoId)
            {
                _context.Notifications.Add(notification);
            }
            await _context.SaveChangesAsync(cancellationToken);

            Achievement achievement = new Achievement();
            if (user.Achievements.Count != 0)
            {
                var userCommentAchievements = user.Achievements.Where(a => a.Category == "Komentarze").ToList();
                if (userCommentAchievements.Count != 0)
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Komentarze" && 
                        a.Amount > userCommentAchievements.Last().Amount);
                }
                else
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Komentarze");
                }
            }
            else
            {
                achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Komentarze");
            }
            var amountOfComment = _context.Comments.Where(a => a.StatusId == 1 && a.CreatedBy == user.Username).ToList().Count;
            if(amountOfComment == achievement.Amount)
            {
                user.Achievements.Add(achievement);
            }

            comment.UserId = user.Id;
            await _context.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }
    }
}
