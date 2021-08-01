using AppForSkills.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditComment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public EditCommentCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.StatusId == 1 && c.Id == request.Id);
            comment.CommentText = request.CommentText;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
