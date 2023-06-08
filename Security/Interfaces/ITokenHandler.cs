using Domain;

namespace Security
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}