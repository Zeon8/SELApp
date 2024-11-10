using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.FirebasePushNotifications;
using Plugin.FirebasePushNotifications.Model;
using SELApp.Models;
using SELApp.Services;

namespace SELApp.ViewModels
{
    public partial class AuthPageViewModel : ObservableObject
    {
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

        [ObservableProperty]
        private string? _errorMessage;

        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;
        private readonly ISessionStorageService _sessionStorage;
        private readonly IFirebasePushNotification _pushNotification;
        private readonly INotificationPermissions _notificationPermissions;

        public AuthPageViewModel(IAuthService authService, INavigationService navigationService,
            ISessionStorageService sessionStorage, 
            IFirebasePushNotification pushNotification, 
            INotificationPermissions notificationPermissions)
        {
            _authService = authService;
            _navigationService = navigationService;
            _sessionStorage = sessionStorage;
            _pushNotification = pushNotification;
            _notificationPermissions = notificationPermissions;
        }

        [RelayCommand]
        public async Task SingIn()
        {
            if (string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Password))
                return;

            string token = await GetFirebaseToken();
            User? user = await _authService.Authorize(PhoneNumber, Password, token);
            if (user is not null)
            {
                await _sessionStorage.Save(user);
                await _navigationService.GoToMainPage(user);
            }
            else
                ErrorMessage = "Помилка авторизації: Невірний логін або пароль.";
        }

        private async Task<string> GetFirebaseToken()
        {
            var status = await _notificationPermissions.GetAuthorizationStatusAsync();
            if (status != AuthorizationStatus.Granted)
                await _notificationPermissions.RequestPermissionAsync();

            await _pushNotification.RegisterForPushNotificationsAsync();
            return _pushNotification.Token;
        }
    }
}
