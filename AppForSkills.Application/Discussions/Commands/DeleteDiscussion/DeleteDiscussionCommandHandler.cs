using AppForSkills.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeleteDiscussion
{
    public class DeleteDiscussionCommandHandler : IRequestHandler<DeleteDiscussionCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public DeleteDiscussionCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteDiscussionCommand request, CancellationToken cancellationToken)
        {
            var discussion = await _context.Discussions.Where(c => c.StatusId == 1 && c.Id == request.Id)
                .Include(d => d.PostsInDiscussion)
                .FirstOrDefaultAsync(cancellationToken);

            _context.Discussions.Remove(discussion);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
