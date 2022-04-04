using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<PostInDiscussion>(request);

            var discussion = _context.Discussions.Where(u => u.StatusId == 1 && u.Id == request.DiscussionId)
                .Include(s => s.UsersInDiscussion).FirstOrDefault();

            if (discussion == null)
            {
                throw new WrongIDException("Discussion not exists. Wrong Id");
            }

            _context.PostsInDiscussion.Add(post);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == post.CreatedBy)
                .Include(u => u.Discussions)
                .Include(u => u.Achievements)
                .FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            Achievement achievement = new Achievement();
            if (user.Achievements.Count != 0)
            {
                var userDiscussionPostsAchievements = user.Achievements.Where(a => a.Category == "Posty w dyskusjach").ToList();
                if(userDiscussionPostsAchievements.Count != 0)
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Posty w dyskusjach" &&
                        a.Amount > userDiscussionPostsAchievements.Last().Amount);
                }
                else
                {
                    achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Posty w dyskusjach");
                }

            }
            else
            {
                achievement = _context.Achievements.FirstOrDefault(a => a.Category == "Posty w dyskusjach");
            }
            var amountOfDiscussionPost = _context.PostsInDiscussion.Where(a => a.StatusId == 1 && a.CreatedBy == user.Username).ToList().Count;
            if (amountOfDiscussionPost == achievement.Amount)
            {
                user.Achievements.Add(achievement);
                await _context.SaveChangesAsync(cancellationToken);
            }
            

            post.UserId = user.Id;

            if (!discussion.UsersInDiscussion.Contains(user))
            {
                discussion.UsersInDiscussion.Add(user);
                user.Discussions.Add(discussion);
                await _context.SaveChangesAsync(cancellationToken);
                Achievement achievement1 = new Achievement();
                if (user.Achievements.Count != 0)
                {
                    var userDiscussionAchievements = user.Achievements.Where(a => a.Category == "Dyskusje").ToList();
                    if (userDiscussionAchievements.Count != 0)
                    {
                        achievement1 = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje" &&
                            a.Amount > userDiscussionAchievements.Last().Amount);
                    }
                    else
                    {
                        achievement1 = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje");
                    }
                }
                else
                {
                    achievement1 = _context.Achievements.FirstOrDefault(a => a.Category == "Dyskusje");
                }
                var amountOfDiscussion = user.Discussions.Count;
                if (amountOfDiscussion == achievement1.Amount)
                {
                    user.Achievements.Add(achievement1);
                }
            }
            await _context.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
