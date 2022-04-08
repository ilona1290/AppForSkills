using AppForSkills.Application.Notifications.Queries.GetAllNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.Commands.ReadNotifications
{
    public class ReadNotificationsCommand : IRequest
    {
        public List<NotificationDto> Notifications { get; set; }
    }
}
