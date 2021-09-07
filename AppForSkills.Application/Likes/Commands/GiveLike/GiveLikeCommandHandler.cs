using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Commands.GiveLike
{
    public class GiveLikeCommandHandler : IRequestHandler<GiveLikeCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public GiveLikeCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(GiveLikeCommand request, CancellationToken cancellationToken)
        {
            var like = _mapper.Map<Like>(request);
            _context.Likes.Add(like);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
