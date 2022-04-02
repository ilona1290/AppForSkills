using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class ListLikes
    {
        public ICollection<LikeDto> Likes { get; set; }
    }
}
