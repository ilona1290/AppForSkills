﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppForSkills.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>, IMapFrom<User>
    {
        public string Username { get; set; }
        public string RegistrationDate { get; set; }
        public string RecentLoginDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, User>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.Username))
                .ForMember(s => s.RegistrationDate, map => map.MapFrom(src => src.RegistrationDate))
                .ForMember(s => s.RecentLoginDate, map => map.MapFrom(src => src.RecentLoginDate))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
