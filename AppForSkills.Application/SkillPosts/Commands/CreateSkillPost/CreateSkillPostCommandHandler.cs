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

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommandHandler : IRequestHandler<CreateSkillPostCommand, int>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStore _fileStore;

        public CreateSkillPostCommandHandler(IAppForSkillsDbContext context, IMapper mapper, IFileStore fileStore)
        {
            _context = context;
            _mapper = mapper;
            _fileStore = fileStore;
        }

        public async Task<int> Handle(CreateSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = _mapper.Map<SkillPost>(request);

            skillPost.AddressOfPhotoOrVideo = "images/" + request.NameOfPhotoOrVideo;

            _context.SkillPosts.Add(skillPost);

            await _context.SaveChangesAsync(cancellationToken);

            return skillPost.Id;
        }
    }
}
