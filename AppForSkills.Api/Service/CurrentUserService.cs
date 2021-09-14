using AppForSkills.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
