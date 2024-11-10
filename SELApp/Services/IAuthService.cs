using SELApp.Models;

namespace SELApp.Services
{
    public interface IAuthService
    {
        public Task<User?> Authorize(string username, string password, string firebaseToken);
    }
}
