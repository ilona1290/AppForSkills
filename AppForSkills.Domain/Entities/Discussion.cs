using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class Discussion : AuditableEntity
    {
        public string FirstPost { get; set; }
        public ICollection<PostInDiscussion> PostsInDiscussion { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<UserInformation> UsersInThisDiscussion { get; set; }

    }
}
