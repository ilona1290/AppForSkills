namespace AppForSkills.Client.Models
{
    public class CommentForm
    {
        public string CommentText { get; set; }
        public int SkillPostId { get; set; }
        public int? MainParentCommentId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
