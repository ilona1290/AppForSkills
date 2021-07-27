using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> UsersWithAchivement { get; set; }
    }
}
