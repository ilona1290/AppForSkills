using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost
{
    public class GetRatingsToSkillPostQueryHandler : IRequestHandler<GetRatingsToSkillPostQuery, RatingsPostVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetRatingsToSkillPostQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingsPostVm> Handle(GetRatingsToSkillPostQuery request, CancellationToken cancellationToken)
        {
            var ratingsPost = _context.Ratings.Where(r => r.StatusId == 1 && r.SkillPostId == request.SkillId)
                .OrderByDescending(s => s.Created);
            var ratingPostDtos = await ratingsPost.ProjectTo<RatingPostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var ratingsPostVm = new RatingsPostVm
            {
                RatingsPost = ratingPostDtos
            };

            return ratingsPostVm;
        }
    }
}
