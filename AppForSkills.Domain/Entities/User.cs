using System;
using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
        public ICollection<SkillPost> UserSkills { get; set; }
        public ICollection<Comment> UserComments { get; set; }
        public ICollection<Rating> GavedRatings { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
    }
}
