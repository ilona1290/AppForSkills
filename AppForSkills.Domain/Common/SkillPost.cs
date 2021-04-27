using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Common
{
    public class SkillPost : AuditableEntity
    {
        public string AddressOfPhotoOrVideoWithSkill { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public int NumberOfRatings { get; set; }
        public float AverageRating { get; set; }
        public int NumberOfComments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
