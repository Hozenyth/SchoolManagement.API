namespace SchoolManagement.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
    }
}
