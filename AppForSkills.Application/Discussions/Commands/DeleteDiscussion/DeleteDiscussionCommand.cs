using MediatR;

namespace AppForSkills.Application.Discussions.Commands.DeleteDiscussion
{
    public class DeleteDiscussionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
