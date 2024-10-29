using System.Text.Json;
using SELApp.Models;

namespace SELApp.Services
{
    public class StorageService : ISessionStorageService
    {
        public async Task<User?> Load()
        {
            string path = GetPath();
            if (File.Exists(path))
            {
                string data = await File.ReadAllTextAsync(path);
                return JsonSerializer.Deserialize<User>(data);
            }
            return null;
        }

        public Task Save(User user)
        {
            string path = GetPath();
            string data = JsonSerializer.Serialize(user);
            return File.WriteAllTextAsync(path, data);
        }

        private static string GetPath()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(folderPath, "user.json");
        }
    }
}
