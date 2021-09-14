using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditRating
{
    public class EditRatingCommandHandler : IRequestHandler<EditRatingCommand>
    {
        private readonly IAppForSkillsDbContext _context;

        public EditRatingCommandHandler(IAppForSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _context.Ratings.FirstOrDefault(r => r.StatusId == 1 && r.Id == request.Id);

            if (rating == null)
            {
                throw new WrongIDException("Rating with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
            }

            rating.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
