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

namespace AppForSkills.Application.SkillPosts.Commands.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateRatingCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Rating>(request);

            var skillPost = _context.SkillPosts.Where(u => u.StatusId == 1 && u.Id == request.SkillPostId)
                .FirstOrDefault();

            if (skillPost == null)
            {
                throw new WrongIDException("SkillPost not exists. Wrong Id");
            }

            _context.Ratings.Add(rating);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == rating.CreatedBy)
                .Include(u => u.Achievements).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            var notification = new Notification()
            {
                FromWhoId = user.Id,
                ToWhoId = skillPost.UserId,
                When = DateTime.Now,
                Message = "Ocenił(a) Twój SkillPost \"" + skillPost.Title + "\" na: " + rating.Value + " gwiazdek."
            };

            if (notification.FromWhoId != notification.ToWhoId)
            {
                _context.Notifications.Add(notification);
            }
            await _context.SaveChangesAsync(cancellationToken);

            Achievement achievement = new Achievement();
            if (user.Achievements.Count != 0)
            {
                var userRatingAchievements = user.Achievements.Where(a => a.Category == "Oceny").ToList();
                if (userRatingAchievements.Count != 0)
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Oceny" &&
                        a.Amount > userRatingAchievements.Last().Amount);
                }
                else
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Oceny");
                }
            }
            else
            {
                achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Oceny");
            }
            var amountOfRating = _context.Ratings.Where(a => a.StatusId == 1 && a.CreatedBy == user.Username).ToList().Count;
            if (amountOfRating == achievement.Amount)
            {
                user.Achievements.Add(achievement);
            }

            rating.UserId = user.Id;
            await _context.SaveChangesAsync(cancellationToken);

            return rating.Id;
        }
    }
}
