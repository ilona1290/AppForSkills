using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Discussions.GetDiscussions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserDiscussions
{
    public class GetUserDiscussionsQueryHandler : IRequestHandler<GetUserDiscussionsQuery, DiscussionsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserDiscussionsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiscussionsVm> Handle(GetUserDiscussionsQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(u => u.StatusId == 1 && u.Username == request.Username);
            var discussions = _context.Discussions.Where(d => d.StatusId == 1 && d.UsersInDiscussion.Contains(user));

            var discussionDtos = await discussions.ProjectTo<DiscussionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var discussionsVm = new DiscussionsVm
            {
                Discussions = discussionDtos
            };

            return discussionsVm;
        }
    }
}
