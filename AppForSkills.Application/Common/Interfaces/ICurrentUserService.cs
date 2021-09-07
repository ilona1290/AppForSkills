namespace AppForSkills.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Username { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
