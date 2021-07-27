using AppForSkills.Domain.Common;
using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class SkillPost : AuditableEntity
    {
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
