using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteRating
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public DeleteRatingCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _context.Ratings.Where(r => r.StatusId == 1 && r.Id == request.RatingId)
                .FirstOrDefaultAsync(cancellationToken);

            if (rating == null)
            {
                throw new WrongIDException("Rating with gaved id could not delete, because not exists in database. " +
                    "Give another id.");
            }

            _context.Ratings.Remove(rating);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
