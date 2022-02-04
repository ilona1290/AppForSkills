using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class ListSkillPost
    {
        public ICollection<SkillPostDto> SkillPosts { get; set; }
    }
}
