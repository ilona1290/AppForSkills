using MediatR;

namespace AppForSkills.Application.Discussions.Commands.ReportPost
{
    public class ReportPostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
