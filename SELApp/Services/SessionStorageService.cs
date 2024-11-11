using System.Text.Json;
using SELApp.Models;

namespace SELApp.Services
{
    public class SessionStorageService
    {
        private User? _user;

        public async Task<User?> GetUser()
        {
            if(_user is not null)
                return _user;

            string? data = await SecureStorage.GetAsync("user");
            if(data is null) return null;
            return _user = JsonSerializer.Deserialize<User>(data);
        }

        public Task Save(User user)
        {
            string data = JsonSerializer.Serialize(user);
            return SecureStorage.SetAsync("user", data);
        }

        public void RemoveUser() => SecureStorage.Remove("user");

    }
}
