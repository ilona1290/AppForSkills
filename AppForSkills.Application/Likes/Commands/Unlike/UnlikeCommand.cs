using MediatR;

namespace AppForSkills.Application.Likes.Commands.Unlike
{
    public class UnlikeCommand : IRequest
    {
        public int LikeId { get; set; }
    }
}
