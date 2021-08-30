using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest, IMapFrom<User>
    {
        public string Username { get; set; }
        public string RegistrationDate { get; set; }
        public string RecentLoginDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, User>()
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
