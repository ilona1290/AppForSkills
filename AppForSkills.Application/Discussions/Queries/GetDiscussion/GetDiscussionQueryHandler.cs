using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class GetDiscussionQueryHandler : IRequestHandler<GetDiscussionQuery, DiscussionVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetDiscussionQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DiscussionVm> Handle(GetDiscussionQuery request, CancellationToken cancellationToken)
        {
            var discussion = await _context.Discussions.Where(d => d.StatusId == 1 && d.Id == request.DiscussionId)
                .Include(d => d.Likes)
                .Include(p => p.PostsInDiscussion.Where(d => d.StatusId == 1 && d.Reported == false)).ThenInclude(l => l.Likes)
                .FirstOrDefaultAsync(cancellationToken);

            if (discussion == null)
            {
                throw new WrongIDException("Discussion with gaved id could not display, because not exists in database. " +
                    "Give another id.");
            }

            var discussionVm = _mapper.Map<DiscussionVm>(discussion);

            return discussionVm;
        }
    }
}
