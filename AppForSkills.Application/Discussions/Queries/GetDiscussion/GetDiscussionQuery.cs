using MediatR;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class GetDiscussionQuery : IRequest<DiscussionVm>
    {
        public int DiscussionId { get; set; }
    }
}
