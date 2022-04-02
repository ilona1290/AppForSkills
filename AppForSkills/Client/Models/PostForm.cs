namespace AppForSkills.Client.Models
{
    public class PostForm
    {
        public string PostText { get; set; }
        public int DiscussionId { get; set; }
        public int? MainParentPostId { get; set; }
        public int? ParentPostId { get; set; }
    }
}
