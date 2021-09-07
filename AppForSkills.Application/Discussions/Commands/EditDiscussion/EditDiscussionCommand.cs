using MediatR;

namespace AppForSkills.Application.Discussions.Commands.EditDiscussion
{
    public class EditDiscussionCommand : IRequest
    {
        public int DiscussionId { get; set; }
        public string FirstPost { get; set; }
    }
}
