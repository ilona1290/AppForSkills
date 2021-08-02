using AppForSkills.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            post.Reported = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
