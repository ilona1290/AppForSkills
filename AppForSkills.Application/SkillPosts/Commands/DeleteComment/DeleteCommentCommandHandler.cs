using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public DeleteCommentCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.Where(c => c.StatusId == 1 && c.Id == request.CommentId)
                .FirstOrDefaultAsync(cancellationToken);

            var comments = await _context.Comments.Where(c => c.StatusId == 1 && c.ParentCommentId == comment.Id)
                .ToListAsync(cancellationToken);

            if (comment == null)
            {
                throw new WrongIDException("Comment with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
            }

            foreach (var com in comments)
            {
                _context.Comments.Remove(com);
            }

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
