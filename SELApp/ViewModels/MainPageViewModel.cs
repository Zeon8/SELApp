using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SELApp.Models;
using SELApp.Services;

namespace SELApp.ViewModels
{
    [QueryProperty(nameof(User), "user")]
    public partial class MainPageViewModel : ObservableObject
    {
        public string GreetingMessage => $"Вас авторизовано, {User?.ShortName}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(GreetingMessage))]
        private User _user = default!;

        private readonly ISessionStorageService _sessionStorage;
        private readonly INavigationService _navigation;

        public MainPageViewModel(ISessionStorageService sessionStorage, INavigationService navigation)
        {
            _sessionStorage = sessionStorage;
            _navigation = navigation;
        }

        [RelayCommand]
        private Task Signout()
        {
            _sessionStorage.Delete();
            return _navigation.GoToAuthPage();
        }
    }
}
