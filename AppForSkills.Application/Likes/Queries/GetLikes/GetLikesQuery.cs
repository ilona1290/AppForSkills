using MediatR;

namespace AppForSkills.Application.Likes.Queries.GetLikes
{
    public class GetLikesQuery : IRequest<LikesVm>
    {
        public int? PostInDiscussionId { get; set; }
        public int? DiscussionId { get; set; }
        public int? CommentId { get; set; }
    }
}
