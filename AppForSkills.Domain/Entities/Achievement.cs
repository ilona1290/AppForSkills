using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public ICollection<User> UsersWithAchivement { get; set; }
    }
}
