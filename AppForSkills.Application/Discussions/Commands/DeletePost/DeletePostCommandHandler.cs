﻿using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public DeletePostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.PostsInDiscussion.Where(c => c.StatusId == 1 && c.Id == request.PostId)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(cancellationToken);

            if (post == null)
            {
                throw new WrongIDException("Post with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
            }

            _context.PostsInDiscussion.Remove(post);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
