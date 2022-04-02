namespace AppForSkills.Client.Models
{
    public class SkillPostDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public int Comment { get; set; }
        public int Rating { get; set; }
    }
}
