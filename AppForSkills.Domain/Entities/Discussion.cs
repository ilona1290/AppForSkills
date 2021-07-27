using AppForSkills.Domain.Common;
using System.Collections.Generic;

namespace AppForSkills.Domain.Entities
{
    public class Discussion : AuditableEntity
    {
        public string FirstPost { get; set; }
        public ICollection<PostInDiscussion> PostsInDiscussion { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<User> UsersInDiscussion { get; set; }

    }
}
