﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Commands.GiveLike
{
    public class GiveLikeCommand : IRequest, IMapFrom<Like>
    {
        public string User { get; set; }
        public int? PostInDiscussionId { get; set; }
        public int? DiscussionId { get; set; }
        public int? CommentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GiveLikeCommand, Like>();
        }
    }
}
