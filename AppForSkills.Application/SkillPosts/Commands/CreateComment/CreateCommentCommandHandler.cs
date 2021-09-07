using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);

            var skillPost = _context.SkillPosts.Where(u => u.StatusId == 1 && u.Id == request.SkillPostId)
                .FirstOrDefault();

            if (skillPost == null)
            {
                throw new WrongIDException("SkillPost not exists. Wrong Id");
            }

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync(cancellationToken);

            var user = _context.Users.Where(u => u.StatusId == 1 && u.Username == comment.CreatedBy).FirstOrDefault();

            if (user == null)
            {
                throw new WrongIDException("User not exists.");
            }

            comment.UserId = user.Id;
            await _context.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }
    }
}
