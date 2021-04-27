using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class PostInDiscussion : AuditableEntity
    {
        public string PostText { get; set; }
        public int NumberOfLikes { get; set; }
        public int DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        public ICollection<LikeToPost> Likes { get; set; }
        public int? ParentPostId { get; set; }
        public ICollection<PostInDiscussion> AnswersToPost { get; set; }
    }
}
