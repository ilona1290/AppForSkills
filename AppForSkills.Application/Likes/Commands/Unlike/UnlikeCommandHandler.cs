﻿using AppForSkills.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Commands.Unlike
{
    public class UnlikeCommandHandler : IRequestHandler<UnlikeCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public UnlikeCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UnlikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _context.Likes.Where(l => l.Id == request.LikeId)
                .FirstOrDefaultAsync(cancellationToken);

            _context.Likes.Remove(like);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
