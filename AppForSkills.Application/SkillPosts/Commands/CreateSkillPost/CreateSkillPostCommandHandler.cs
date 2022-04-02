using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommandHandler : IRequestHandler<CreateSkillPostCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateSkillPostCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = _mapper.Map<SkillPost>(request);

            _context.SkillPosts.Add(skillPost);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == skillPost.CreatedBy).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            skillPost.UserId = user.Id;
            await _context.SaveChangesAsync(cancellationToken);

            return skillPost.Id;
        }
    }
}
