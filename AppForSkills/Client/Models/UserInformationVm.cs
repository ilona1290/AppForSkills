using System;

namespace AppForSkills.Client.Models
{
    public class UserInformationVm
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
        public int UserSkills { get; set; }
        public int UserComments { get; set; }
        public int GavedRatings { get; set; }
        public int Achievements { get; set; }
        public int Discussions { get; set; }
    }
}
