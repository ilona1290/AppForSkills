using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            /*if(request.ParentCommentId != null)
            {
                var parentComment = _context.Comments.FirstOrDefault(c => c.Id == request.ParentCommentId);
                parentComment.AnswersToComment.Add(comment);
            }*/

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }
}
