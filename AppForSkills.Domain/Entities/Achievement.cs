using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInformation> UsersWithAchivement { get; set; }
    }
}
