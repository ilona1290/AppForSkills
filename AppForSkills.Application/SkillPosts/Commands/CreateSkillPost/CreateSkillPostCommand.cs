using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommand : IRequest<int>, IMapFrom<SkillPost>
    {
        public string NameOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSkillPostCommand, SkillPost>();
        }
    }
}
