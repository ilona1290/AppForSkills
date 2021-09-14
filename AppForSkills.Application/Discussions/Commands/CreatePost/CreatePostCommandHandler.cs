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
                .Include(u => u.Discussions).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            post.UserId = user.Id;

            discussion.UsersInDiscussion.Add(user);
            user.Discussions.Add(discussion);
            await _context.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
