using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Queries.GetLikes
{
    public class GetLikesQuery : IRequest<LikesVm>
    {
        public int? PostInDiscussionId { get; set; }
        public int? DiscussionId { get; set; }
        public int? CommentId { get; set; }
    }
}
