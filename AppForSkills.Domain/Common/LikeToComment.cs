using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Common
{
    public class LikeToComment : AuditableEntity
    {
        public int CommentId { get; set; }
    }
}
