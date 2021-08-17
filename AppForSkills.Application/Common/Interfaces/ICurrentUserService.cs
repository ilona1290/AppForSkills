using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Username { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
