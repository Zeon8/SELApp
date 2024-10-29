using SELApp.Models;

namespace SELApp.Services
{
    public interface IAuthService
    {
        public Task<User?> TryAuthorize(string username, string password, string firebaseToken);
    }
}
