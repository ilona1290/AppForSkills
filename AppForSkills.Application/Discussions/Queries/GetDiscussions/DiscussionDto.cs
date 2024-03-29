﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System.Linq;

namespace AppForSkills.Application.Discussions.GetDiscussions
{
    public class DiscussionDto : IMapFrom<Discussion>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string FirstPost { get; set; }
        public int Posts { get; set; }
        public int Likes { get; set; }
        public int Users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Discussion, DiscussionDto>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.UsersInDiscussion.FirstOrDefault(a => a.Username == Username).Avatar))
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Posts, map => map.MapFrom(src => src.PostsInDiscussion
                    .Where(p => p.Reported == false).Count()))
                .ForMember(s => s.Likes, map => map.MapFrom(src => src.Likes.Count))
                .ForMember(s => s.Users, map => map.MapFrom(src => src.UsersInDiscussion.Count));
        }
    }
}
