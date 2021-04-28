using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class LikeToDiscussion
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        public string User { get; set; }
    }
}
