namespace User.Domain.Interfaces.API
{
    public interface ITokenGenerator
    {
        string GenerateToken(string login, string role);
    }
}
