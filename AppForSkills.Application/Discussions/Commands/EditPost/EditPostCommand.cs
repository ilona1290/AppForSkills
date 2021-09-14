using MediatR;

namespace AppForSkills.Application.Discussions.Commands.EditPost
{
    public class EditPostCommand : IRequest
    {
        public int Id { get; set; }
        public string PostText { get; set; }
    }
}
