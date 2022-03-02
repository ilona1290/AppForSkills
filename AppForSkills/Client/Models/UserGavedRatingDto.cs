using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class UserGavedRatingDto
    {
        public int Value { get; set; }
        public int SkillId { get; set; }
        public string AuthorOfSkill { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
