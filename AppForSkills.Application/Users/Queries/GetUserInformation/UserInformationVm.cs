using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;

namespace AppForSkills.Application.Users.Queries.GetUserInformation
{
    public class UserInformationVm : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
        public int UserSkills { get; set; }
        public int UserComments { get; set; }
        public int GavedRatings { get; set; }
        public int Achievements { get; set; }
        public int Discussions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserInformationVm>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.Avatar))
                .ForMember(s => s.Username, map => map.MapFrom(src => src.Username))
                .ForMember(s => s.RegistrationDate, map => map.MapFrom(src => src.RegistrationDate))
                .ForMember(s => s.RecentLoginDate, map => map.MapFrom(src => src.RecentLoginDate))
                .ForMember(s => s.UserSkills, map => map.MapFrom(src => src.UserSkills.Count))
                .ForMember(s => s.UserComments, map => map.MapFrom(src => src.UserComments.Count))
                .ForMember(s => s.GavedRatings, map => map.MapFrom(src => src.GavedRatings.Count))
                .ForAllOtherMembers(s => s.Ignore());
        }
    }
}
