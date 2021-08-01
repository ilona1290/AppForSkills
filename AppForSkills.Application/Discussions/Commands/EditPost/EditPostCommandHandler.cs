using AppForSkills.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditPost
{
    public class EditPostCommandHandler : IRequestHandler<EditPostCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public EditPostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = _context.PostsInDiscussion.FirstOrDefault(c => c.StatusId == 1 && c.Id == request.Id);
            post.PostText = request.PostText;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
