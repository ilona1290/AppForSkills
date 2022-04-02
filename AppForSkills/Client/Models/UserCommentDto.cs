using System;
using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class UserCommentDto
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public DateTime Date { get; set; }
        public string CommentText { get; set; }
        public int? MainParentCommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public CommentDto ParentComment { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
