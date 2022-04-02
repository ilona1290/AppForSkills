using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class ListUserComments
    {
        public ICollection<UserCommentDto> Comments { get; set; }
    }
}
