using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.GetDiscussions
{
    public class GetDiscussionsQueryHandler : IRequestHandler<GetDiscussionsQuery, DiscussionsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetDiscussionsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiscussionsVm> Handle(GetDiscussionsQuery request, CancellationToken cancellationToken)
        {
            var discussions = _context.Discussions.OrderByDescending(s => s.Created);
            var discussionDtos = await discussions.ProjectTo<DiscussionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var discussionsVm = new DiscussionsVm
            {
                Discussions = discussionDtos
            };

            return discussionsVm;
        }
    }
}
