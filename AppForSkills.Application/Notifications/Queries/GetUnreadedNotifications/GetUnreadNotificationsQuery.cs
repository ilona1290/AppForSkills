using AppForSkills.Application.Notifications.Queries.GetAllNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.GetUnreadNotifications
{
    public class GetUnreadNotificationsQuery : IRequest<NotificationsVm>
    {
        public string Username { get; set; }
    }
}
