using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string FromWho { get; set; }
        public DateTime When { get; set; }
        public string Message { get; set; }
    }
}
