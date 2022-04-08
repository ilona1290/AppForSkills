﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.GetAllNotifications
{
    public class GetAllNotificationsQuery : IRequest<NotificationsVm>
    {
        public string Username { get; set; }
    }
}
