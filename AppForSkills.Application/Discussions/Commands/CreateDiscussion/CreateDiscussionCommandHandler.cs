using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreateDiscussion
{
    public class CreateDiscussionCommandHandler : IRequestHandler<CreateDiscussionCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public CreateDiscussionCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDiscussionCommand request, CancellationToken cancellationToken)
        {
            var discussion = _mapper.Map<Discussion>(request);

            _context.Discussions.Add(discussion);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == discussion.CreatedBy)
                .Include(u => u.Discussions).Include(u => u.Achievements).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            

            discussion.UsersInDiscussion = new List<User>
            {
                user
            };

            user.Discussions.Add(discussion);
            await _context.SaveChangesAsync(cancellationToken);

            Achievement achievement = new Achievement();
            if (user.Achievements.Count != 0)
            {
                var userDiscussionAchievements = user.Achievements.Where(a => a.Category == "Dyskusje").ToList();
                if (userDiscussionAchievements.Count != 0)
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje" &&
                        a.Amount > userDiscussionAchievements.Last().Amount);
                }
                else
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje");
                }
            }
            else
            {
                achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje");
            }
            var amountOfDiscussion = user.Discussions.Count;
            if (amountOfDiscussion == achievement.Amount)
            {
                user.Achievements.Add(achievement);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return discussion.Id;
        }
    }
}
