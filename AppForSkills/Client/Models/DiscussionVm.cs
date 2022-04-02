using System;
using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class DiscussionVm
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime PublishingDate { get; set; }
        public string FirstPost { get; set; }
        public ICollection<PostInDiscussionDto> Posts { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
