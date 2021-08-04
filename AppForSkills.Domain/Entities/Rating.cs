using AppForSkills.Domain.Common;

namespace AppForSkills.Domain.Entities
{
    public class Rating : AuditableEntity
    {
        public int Value { get; set; }
        public int SkillPostId { get; set; }
        public SkillPost SkillPost { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
