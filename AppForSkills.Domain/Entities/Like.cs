using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int? PostInDiscussionId { get; set; }
        public PostInDiscussion PostInDiscussion { get; set; }
        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        public int? CommentId { get; set; }
        public Comment Commment { get; set; }
        public string User { get; set; }
    }
}
