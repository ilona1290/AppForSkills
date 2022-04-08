using AppForSkills.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.Commands.ReadNotifications
{
    public class ReadNotificationsCommandHandler : IRequestHandler<ReadNotificationsCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public ReadNotificationsCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(ReadNotificationsCommand request, CancellationToken cancellationToken)
        {
            foreach (var not in request.Notifications)
            {
                var notification = _context.Notifications.FirstOrDefault(n => n.Id == not.Id);
                notification.IsRead = true;

                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
