﻿using AppForSkills.Application.Common.Interfaces;
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

namespace AppForSkills.Application.SkillPosts.Commands.EditRating
{
    public class EditRatingCommandHandler : IRequestHandler<EditRatingCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public EditRatingCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _context.Ratings.FirstOrDefault(r => r.StatusId == 1 && r.Id == request.Id);

            rating.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
