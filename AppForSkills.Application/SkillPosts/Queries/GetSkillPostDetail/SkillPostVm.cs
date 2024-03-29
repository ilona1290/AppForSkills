﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class SkillPostVm : IMapFrom<SkillPost>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime PublishingDate { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public ICollection<CommentDto> Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SkillPost, SkillPostVm>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.PublishingDate, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.Rating, map => map.Ignore())
                .IncludeMembers(s => s.User);

            profile.CreateMap<User, SkillPostVm>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.Avatar))
                .ForAllOtherMembers(f => f.Ignore());
        }
    }
}
