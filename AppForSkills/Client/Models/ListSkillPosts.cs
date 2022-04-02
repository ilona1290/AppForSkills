using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class ListSkillPosts
    {
        public ICollection<SkillPostDto> SkillPosts { get; set; }
    }
}
