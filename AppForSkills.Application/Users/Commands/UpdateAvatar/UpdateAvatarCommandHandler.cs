using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.UpdateAvatar
{
    public class UpdateAvatarCommandHandler : IRequestHandler<UpdateAvatarCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public UpdateAvatarCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(c => c.StatusId == 1 && c.Username == request.Username);

            if (user == null)
            {
                throw new WrongIDException("User not exists in database.");
            }

            user.Avatar = request.Avatar;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
