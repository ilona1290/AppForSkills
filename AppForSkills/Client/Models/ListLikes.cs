using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Client.Models
{
    public class ListLikes
    {
        public ICollection<LikeDto> Likes { get; set; }
    }
}
