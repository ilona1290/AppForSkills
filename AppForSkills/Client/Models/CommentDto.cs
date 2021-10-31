using System;
using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
