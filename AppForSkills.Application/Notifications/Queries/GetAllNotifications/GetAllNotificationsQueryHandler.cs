using AppForSkills.Application.Common.Interfaces;
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

namespace AppForSkills.Application.Notifications.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQuery, NotificationsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetAllNotificationsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationsVm> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = _context.Notifications.Where(d => d.ToWho.Username == request.Username).OrderByDescending(s => s.When);
            var notificationDtos = await notifications.ProjectTo<NotificationDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var notificationsVm = new NotificationsVm
            {
                Notifications = notificationDtos
            };

            return notificationsVm;
        }
    }
}
