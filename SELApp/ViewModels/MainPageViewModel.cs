using CommunityToolkit.Mvvm.ComponentModel;
using SELApp.Models;

namespace SELApp.ViewModels
{
    [QueryProperty(nameof(User), "user")]
    public partial class MainPageViewModel : ObservableObject
    {
        public string GreetingMessage => $"Вас авторизовано, {User?.ShortName}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(GreetingMessage))]
        private User _user = default!;
    }
}
