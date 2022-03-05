using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class ListUserDiscussionPosts
    {
        public ICollection<UserDiscussionPostDto> DiscussionPosts { get; set; }
    }
}
