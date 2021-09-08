using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.UpdateLoginDate
{
    public class UpdateLoginDateCommandHandler : IRequestHandler<UpdateLoginDateCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        public UpdateLoginDateCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLoginDateCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(c => c.StatusId == 1 && c.Username == request.Username);

            if (user == null)
            {
                throw new WrongIDException("User not exists in database.");
            }

            user.RecentLoginDate = request.RecentLogin;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
