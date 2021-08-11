using AppForSkills.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppForSkills.Api.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var username = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Name);

            Username = username;

            IsAuthenticated = !string.IsNullOrEmpty(username);
        }
    }
}
