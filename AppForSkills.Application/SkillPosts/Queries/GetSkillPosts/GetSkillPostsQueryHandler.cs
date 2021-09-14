using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPosts
{
    public class GetSkillPostsQueryHandler : IRequestHandler<GetSkillPostsQuery, SkillPostsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetSkillPostsQueryHandler(IAppForSkillsDbContext skillsDbContext, IMapper mapper)
        {
            _context = skillsDbContext;
            _mapper = mapper;
        }
        public async Task<SkillPostsVm> Handle(GetSkillPostsQuery request, CancellationToken cancellationToken)
        {
            var skillPosts = _context.SkillPosts.Where(a => a.StatusId == 1).OrderByDescending(s => s.Created);
            var skillPostDtos = await skillPosts.ProjectTo<SkillPostDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var skillPostsVm = new SkillPostsVm
            {
                SkillPosts = skillPostDtos
            };

            return skillPostsVm;
        }
    }
}
