
using System.Net.Http.Json;
using SELApp.Models;

namespace SELApp.Services
{
    public class HttpAuthService
    {
        private readonly HttpClient _httpClient;

        public HttpAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User?> Authorize(string username, string password, string firebaseToken)
        {
            var data = new AuthorizationRequest(username, password, firebaseToken);
            var response = await _httpClient.PostAsJsonAsync("api/get-firebase-id-token", data);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthorizationResponse>();
                return authResponse!.User;
            }
            return null;
        }
    }
}
