using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Application.SkillPosts.Commands.EditComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditSkillPost
{
    public class EditSkillPostCommandHandler : IRequestHandler<EditSkillPostCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public EditSkillPostCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = _context.SkillPosts.FirstOrDefault(c => c.StatusId == 1 && c.Id == request.Id);

            if (skillPost == null)
            {
                throw new WrongIDException("Skill Post with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
            }

            skillPost.AddressOfPhotoOrVideo = request.AddressOfPhotoOrVideo;
            skillPost.Title = request.Title;
            skillPost.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
