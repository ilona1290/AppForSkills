using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreateDiscussion
{
    public class CreateDiscussionCommand : IRequest<int>, IMapFrom<Discussion>
    {
        public string FirstPost { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDiscussionCommand, Discussion>();
        }
    }
}
