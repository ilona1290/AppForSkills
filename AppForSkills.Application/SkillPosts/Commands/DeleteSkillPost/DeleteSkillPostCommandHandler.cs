﻿using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteSkillPost
{
    public class DeleteSkillPostCommandHandler : IRequestHandler<DeleteSkillPostCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public DeleteSkillPostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = await _context.SkillPosts.Where(s => s.StatusId == 1 && s.Id == request.SkillPostId)
                .Include(a => a.Ratings).Include(q => q.Comments)
                .FirstOrDefaultAsync(cancellationToken);

            if (skillPost == null)
            {
                throw new WrongIDException("Skill Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
            }

            _context.SkillPosts.Remove(skillPost);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
