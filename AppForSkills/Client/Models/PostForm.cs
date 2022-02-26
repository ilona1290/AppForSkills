using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class PostForm
    {
        public string PostText { get; set; }
        public int DiscussionId { get; set; }
        public int? ParentPostId { get; set; }
    }
}
