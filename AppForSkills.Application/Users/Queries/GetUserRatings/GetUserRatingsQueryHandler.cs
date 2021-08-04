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

namespace AppForSkills.Application.Users.Queries.GetUserRatings
{
    public class GetUserRatingsQueryHandler : IRequestHandler<GetUserRatingsQuery, RatingsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserRatingsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingsVm> Handle(GetUserRatingsQuery request, CancellationToken cancellationToken)
        {
            var ratings = _context.Ratings.Where(r => r.StatusId == 1 && r.User.Username == request.Username)
                .OrderByDescending(r => r.Created);

            var ratingDtos = await ratings.ProjectTo<RatingDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var ratingsVm = new RatingsVm
            {
                Ratings = ratingDtos
            };

            return ratingsVm;
        }
    }
}
