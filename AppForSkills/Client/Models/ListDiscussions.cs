using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class ListDiscussions
    {
        public ICollection<DiscussionDto> Discussions { get; set; }
    }
}
