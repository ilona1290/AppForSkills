using System;
using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class SkillPostVm
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime PublishingDate { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public float Rating { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
