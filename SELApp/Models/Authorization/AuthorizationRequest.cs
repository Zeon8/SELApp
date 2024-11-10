using System.Text.Json.Serialization;

namespace SELApp.Models.Authorization
{
    public record AuthorizationRequest
    {
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; init; }

        [JsonPropertyName("password")]
        public string Password { get; init; }

        [JsonPropertyName("firebase_token")]
        public string FirebaseToken { get; init; }

        public AuthorizationRequest(string phoneNumber, string password, string firebaseToken)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            FirebaseToken = firebaseToken;
        }
    }
}
