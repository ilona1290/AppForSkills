using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Common
{
    public class Rating : AuditableEntity
    {
        public int Value { get; set; }
        public int SkillId { get; set; }
        public SkillPost SkillPost { get; set; }
    }
}
