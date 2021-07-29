using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateRatingCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Rating>(request);

            _context.Ratings.Add(rating);

            await _context.SaveChangesAsync(cancellationToken);

            return rating.Id;
        }
    }
}
