using System;
using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class PostInDiscussionDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string PostText { get; set; }
        public int? MainParentPostId { get; set; }
        public int? ParentPostId { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
        public int StatusId { get; set; }
        public bool ShowAnswerField { get; set; } = false;
        public bool ShowEditPostField { get; set; } = false;
    }
}
