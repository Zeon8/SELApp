using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SELApp.Models;
using SELApp.Services;

namespace SELApp.ViewModels
{
    public partial class AuthPageViewModel : ObservableObject
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        [ObservableProperty]
        private string? _errorMessage;

        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;
        private readonly ISessionStorageService _sessionStorage;

        public AuthPageViewModel(IAuthService authService, INavigationService navigationService, 
            ISessionStorageService sessionStorage)
        {
            _authService = authService;
            _navigationService = navigationService;
            _sessionStorage = sessionStorage;
        }

        [RelayCommand]
        public async Task SingIn()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return;

            User? user = await _authService.TryAuthorize(Username, Password, "test");
            if (user is not null)
            {
                await _sessionStorage.Save(user);
                await _navigationService.GoToMainPage(user);
            }
            else
                ErrorMessage = "Помилка авторизації: Невірний логін або пароль.";
                
        }
    }
}
