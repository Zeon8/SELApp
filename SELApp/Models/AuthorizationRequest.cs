using System.Text.Json.Serialization;

namespace SELApp.Models
{
    public record AuthorizationRequest
    {
        [JsonPropertyName("id")]
        public string Username { get; init; }

        [JsonPropertyName("password")]
        public string Password { get; init; }

        [JsonPropertyName("firebase_token")]
        public string FirebaseToken { get; init; }

        public AuthorizationRequest(string username, string password, string firebaseToken)
        {
            Username = username;
            Password = password;
            FirebaseToken = firebaseToken;
        }
    }
}
