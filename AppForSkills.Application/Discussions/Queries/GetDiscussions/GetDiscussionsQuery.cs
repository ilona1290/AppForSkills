﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.GetDiscussions
{
    public class GetDiscussionsQuery : IRequest<DiscussionsVm>
    {
    }
}
