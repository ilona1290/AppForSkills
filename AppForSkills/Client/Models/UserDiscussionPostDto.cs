using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class UserDiscussionPostDto
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public string PostText { get; set; }
        public int? MainParentPostId { get; set; }
        public int? ParentPostId { get; set; }
        public PostInDiscussionDto ParentPost { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
