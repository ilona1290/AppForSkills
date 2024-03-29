﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppForSkills.Application.Discussions.Commands.CreateDiscussion
{
    public class CreateDiscussionCommand : IRequest<int>, IMapFrom<Discussion>
    {
        public string FirstPost { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDiscussionCommand, Discussion>()
                .ForMember(m => m.FirstPost, map => map.MapFrom(src => src.FirstPost))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
