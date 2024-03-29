﻿namespace AppForSkills.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Avatar { get; set; } = "";
        public int? PostInDiscussionId { get; set; }
        public PostInDiscussion PostInDiscussion { get; set; }
        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        
    }
}
