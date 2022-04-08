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

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommandHandler : IRequestHandler<CreateSkillPostCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateSkillPostCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = _mapper.Map<SkillPost>(request);

            _context.SkillPosts.Add(skillPost);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == skillPost.CreatedBy)
                .Include(u => u.Achievements).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            Achievement achievement = new Achievement();
            if (user.Achievements.Count != 0)
            {
                var userSkillPostAchievements = user.Achievements.Where(a => a.Category == "Skills").ToList();
                if (userSkillPostAchievements.Count != 0)
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Skills" &&
                        a.Amount > userSkillPostAchievements.Last().Amount);
                }
                else
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Skills");
                }
            }
            else
            {
                achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Skills");
            }
            var amountOfSkillPost = _context.SkillPosts.Where(a => a.StatusId == 1 && a.CreatedBy == user.Username).ToList().Count;
            if (amountOfSkillPost == achievement.Amount)
            {
                user.Achievements.Add(achievement);
            }

            skillPost.UserId = user.Id;
            await _context.SaveChangesAsync(cancellationToken);

            return skillPost.Id;
        }
    }
}
