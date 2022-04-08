using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int? FromWhoId { get; set; }
        public User FromWho { get; set; }
        public int? ToWhoId { get; set; }
        public User ToWho { get; set; }
        public DateTime When { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
