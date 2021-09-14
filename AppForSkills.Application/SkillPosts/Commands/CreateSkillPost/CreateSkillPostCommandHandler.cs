using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.IO;
using System.Linq;
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

            var bytes = _fileStore.FormFileToBytesArray(request.Skill);

            var extension = Path.GetExtension(request.Skill.FileName);
            if(extension == ".jpg" || extension == ".png" || extension == ".gif")
            {
                var fileDir = _fileStore.SafeWriteFile(bytes, request.Skill.FileName, "Images");
                skillPost.AddressOfPhotoOrVideo = "Images/" + request.Skill.FileName;
            }
            else if(extension == ".mp4" || extension == ".avi")
            {
                var fileDir = _fileStore.SafeWriteFile(bytes, request.Skill.FileName, "Videos");
                skillPost.AddressOfPhotoOrVideo = "Videos/" + request.Skill.FileName;
            }
            else
            {
                throw new Exception("Unsupported file format");
            }

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
