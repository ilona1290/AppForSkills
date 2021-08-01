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

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<PostInDiscussion>(request);

            _context.PostsInDiscussion.Add(post);

            await _context.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
