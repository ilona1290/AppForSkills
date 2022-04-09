using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Notifications.Queries.GetAllNotifications
{
    public class NotificationDto : IMapFrom<Notification>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string FromWho { get; set; }
        public DateTime When { get; set; }
        public string Message { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notification, NotificationDto>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.FromWho.Avatar))
                .ForMember(s => s.FromWho, map => map.MapFrom(src => src.FromWho.Username));
        }
    }
}
