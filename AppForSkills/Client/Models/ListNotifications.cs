using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class ListNotifications
    {
        public ICollection<NotificationDto> Notifications { get; set; }
    }
}
