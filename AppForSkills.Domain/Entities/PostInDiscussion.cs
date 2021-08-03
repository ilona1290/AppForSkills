using AppForSkills.Domain.Common;
using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class PostInDiscussion : AuditableEntity
    {
        public string PostText { get; set; }
        public int DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        public ICollection<Like> Likes { get; set; }
        public int? ParentPostId { get; set; }
        public PostInDiscussion ParentPost { get; set; }
        public ICollection<PostInDiscussion> AnswersToPost { get; set; }
        public bool Reported { get; set; } = false;
    }
}
