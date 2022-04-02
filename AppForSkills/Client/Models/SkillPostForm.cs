using System.ComponentModel.DataAnnotations;

namespace AppForSkills.Client.Models
{
    public class SkillPostForm
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Skill { get; set; }
    }
}
