using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Common
{
    public class Comment : AuditableEntity
    {
        public string CommentText { get; set; }
        public int SkillPostId { get; set; }
        public SkillPost SkillPost { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<Comment> AnswersToComment { get; set; }
        public int NumberOfLikesToComment { get; set; }
        public ICollection<LikeToComment> Likes { get; set; }

    }
}
