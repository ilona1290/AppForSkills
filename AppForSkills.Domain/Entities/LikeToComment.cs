using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class LikeToComment : AuditableEntity
    {
        public int CommentId { get; set; }
    }
}
