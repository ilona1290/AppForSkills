using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Notifications.Queries.GetAllNotifications;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.GetUnreadNotifications
{
    public class GetUnreadNotificationsQueryHandler : IRequestHandler<GetUnreadNotificationsQuery, NotificationsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUnreadNotificationsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationsVm> Handle(GetUnreadNotificationsQuery request, CancellationToken cancellationToken)
        {
            var unreadNotifications = _context.Notifications
                .Where(d => d.ToWho.Username == request.Username && d.IsRead == false)
                .OrderByDescending(s => s.When);
            var unreadNotificationsDtos = await unreadNotifications.ProjectTo<NotificationDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var unreadNotificationsVm = new NotificationsVm
            {
                Notifications = unreadNotificationsDtos
            };

            return unreadNotificationsVm;
        }
    }
}
