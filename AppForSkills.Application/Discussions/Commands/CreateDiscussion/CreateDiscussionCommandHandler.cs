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

namespace AppForSkills.Application.Discussions.Commands.CreateDiscussion
{
    public class CreateDiscussionCommandHandler : IRequestHandler<CreateDiscussionCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public CreateDiscussionCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDiscussionCommand request, CancellationToken cancellationToken)
        {
            var discussion = _mapper.Map<Discussion>(request);
                
            _context.Discussions.Add(discussion);

            await _context.SaveChangesAsync(cancellationToken);

            return discussion.Id;
        }
    }
}
