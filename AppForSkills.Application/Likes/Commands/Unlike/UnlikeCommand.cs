using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Command.Unlike
{
    public class UnlikeCommand : IRequest
    {
        public int LikeId { get; set; }
    }
}
