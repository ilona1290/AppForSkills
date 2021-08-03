using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
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

            if(post == null)
            {
                throw new WrongIDException("Post with gaved id could not update, because not exists in database. " +
                    "Give another id.");
            }
            post.PostText = request.PostText;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
