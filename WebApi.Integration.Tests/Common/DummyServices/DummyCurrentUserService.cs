using AppForSkills.Application.Common.Interfaces;

namespace WebApi.Integration.Tests.Common.DummyServices
{
    public class DummyCurrentUserService : ICurrentUserService
    {
        public string Username { get; set; } = "alice";
        public bool IsAuthenticated { get; set; } = true;
    }
}
