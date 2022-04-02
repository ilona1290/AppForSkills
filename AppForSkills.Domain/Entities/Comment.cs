using AppForSkills.Domain.Common;
using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public string CommentText { get; set; }
        public int SkillPostId { get; set; }
        public SkillPost SkillPost { get; set; }
        public int? MainParentCommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<Like> Likes { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
