using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditComment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public EditCommentCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.StatusId == 1 && c.Id == request.Id);

            if (comment == null)
            {
                throw new WrongIDException("Comment with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
            }

            comment.CommentText = request.CommentText;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
