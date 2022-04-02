namespace AppForSkills.Client.Models
{
    public class DiscussionDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstPost { get; set; }
        public int Posts { get; set; }
        public int Likes { get; set; }
        public int Users { get; set; }
        public bool ShowEditDiscField { get; set; } = false;
    }
}
