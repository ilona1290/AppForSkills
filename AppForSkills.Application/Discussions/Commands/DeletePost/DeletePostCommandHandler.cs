using AppForSkills.Application.Common.Interfaces;
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
                .FirstOrDefaultAsync(cancellationToken);

            _context.PostsInDiscussion.Remove(post);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
