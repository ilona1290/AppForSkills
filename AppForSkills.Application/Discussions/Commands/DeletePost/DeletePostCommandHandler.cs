using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public DeletePostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.PostsInDiscussion.Where(c => c.StatusId == 1 && c.Id == request.PostId)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(cancellationToken);

            if (post == null)
            {
                throw new WrongIDException("Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
            }

            _context.PostsInDiscussion.Remove(post);

            await _context.SaveChangesAsync(cancellationToken);

            var posts = await _context.PostsInDiscussion.Where(s => s.StatusId == 1 && s.CreatedBy == post.CreatedBy
                && s.DiscussionId == post.DiscussionId)
                .ToListAsync(cancellationToken);

            if(posts.Count == 0)
            {
                var discussion = await _context.Discussions.Where(p => p.Id == post.DiscussionId)
                    .Include(u => u.UsersInDiscussion)
                    .FirstOrDefaultAsync(cancellationToken);
                var user = await _context.Users.Where(u => u.Username == post.CreatedBy)
                    .Include(d => d.Discussions)
                    .FirstOrDefaultAsync(cancellationToken);
                discussion.UsersInDiscussion.Remove(user);
                user.Discussions.Remove(discussion);
            }
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
