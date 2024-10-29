using SELApp.Models;

namespace SELApp.Services
{
    public interface ISessionStorageService
    {
        Task<User?> Load();
        Task Save(User user);
    }
}
