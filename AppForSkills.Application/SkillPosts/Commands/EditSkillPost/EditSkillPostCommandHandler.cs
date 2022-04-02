using AppForSkills.Application.Common.Enums;
using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System;
using System.IO;
using System.Linq;
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

            skillPost.Title = request.Title;
            skillPost.Description = request.Description;
            skillPost.AddressOfPhotoOrVideo = request.Skill;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
