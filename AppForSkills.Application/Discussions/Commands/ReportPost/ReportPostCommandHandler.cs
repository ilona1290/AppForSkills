using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.ReportPost
{
    public class ReportPostCommandHandler : IRequestHandler<ReportPostCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public ReportPostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ReportPostCommand request, CancellationToken cancellationToken)
        {
            var post = _context.PostsInDiscussion.FirstOrDefault(d => d.StatusId == 1 && d.Id == request.PostId);

            if (post == null)
            {
                throw new WrongIDException("Post with gaved id could not report, because not exists in database. " +
                    "Give another id.");
            }
            post.Reported = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
