using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class CommentForm
    {
        public string CommentText { get; set; }
        public int SkillPostId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
