using AppForSkills.Application.Common.Enums;
using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditSkillPost
{
    public class EditSkillPostCommandHandler : IRequestHandler<EditSkillPostCommand>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IFileStore _fileStore;

        public EditSkillPostCommandHandler(IAppForSkillsDbContext context, IFileStore fileStore)
        {
            _context = context;
            _fileStore = fileStore;
        }

        public async Task<Unit> Handle(EditSkillPostCommand request, CancellationToken cancellationToken)
        {
            var skillPost = _context.SkillPosts.FirstOrDefault(c => c.StatusId == 1 && c.Id == request.Id);

            if (skillPost == null)
            {
                throw new WrongIDException("Skill Post with gaved id could not edit, because not exists in database. " +
                    "Give another id.");
            }

            var bytes = _fileStore.FormFileToBytesArray(request.Skill);

            var fileExisted = File.ReadAllBytes(skillPost.AddressOfPhotoOrVideo);
            var theSame = bytes.SequenceEqual(fileExisted);
            if (!theSame)
            {
                File.Delete(skillPost.AddressOfPhotoOrVideo);
                var extension = Path.GetExtension(request.Skill.FileName).Remove(0, 1);
                if (FileExtension.IsImage(extension))
                {
                    var fileDir = _fileStore.SafeWriteFile(bytes, request.Skill.FileName, "Images");
                    skillPost.AddressOfPhotoOrVideo = "Images\\" + request.Skill.FileName;
                }
                else if (FileExtension.IsVideo(extension))
                {
                    var fileDir = _fileStore.SafeWriteFile(bytes, request.Skill.FileName, "Videos");
                    skillPost.AddressOfPhotoOrVideo = "Videos\\" + request.Skill.FileName;
                }
                else
                {
                    new Exception("Unsupported file format");
                }
            }

            skillPost.Title = request.Title;
            skillPost.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
