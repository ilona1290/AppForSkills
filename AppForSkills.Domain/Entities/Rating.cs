using AppForSkills.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class Rating : AuditableEntity
    {
        public int Value { get; set; }
        public int SkillId { get; set; }
        public SkillPost SkillPost { get; set; }
        public int UserId { get; set; }
        public UserInformation User { get; set; }
    }
}
