using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditDiscussion
{
    public class EditDiscussionCommandHandler : IRequestHandler<EditDiscussionCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public EditDiscussionCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(EditDiscussionCommand request, CancellationToken cancellationToken)
        {
            var discussion = _context.Discussions.FirstOrDefault(d => d.StatusId == 1 && d.Id == request.DiscussionId);

            if (discussion == null)
            {
                throw new WrongIDException("Discussion with gaved id could not update, because not exists in database. " +
                    "Give another id.");
            }

            discussion.FirstPost = request.FirstPost;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
