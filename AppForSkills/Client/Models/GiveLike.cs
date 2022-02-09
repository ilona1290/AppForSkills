using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class GiveLike
    {
        public string User { get; set; }
        public int? PostInDiscussionId { get; set; }
        public int? DiscussionId { get; set; }
        public int? CommentId { get; set; }
    }
}
