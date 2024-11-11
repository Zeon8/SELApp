using System.Text.Json;
using SELApp.Models;
using SELApp.Services;

namespace SELApp.Views;

public partial class StartPage : ContentPage
{
    private readonly NavigationService _navigation;
    private readonly SessionStorageService _sessionStorage;

    public StartPage(NavigationService navigationService, 
        SessionStorageService sessionStorage)
    {
        InitializeComponent();
        _navigation = navigationService;
        _sessionStorage = sessionStorage;

        Task.Run(LoadPage);
    }

    private async Task LoadPage()
    {
        User? user = await _sessionStorage.GetUser();
        if(user is not null)
            await _navigation.GoToMainPage(user);
        else
            await _navigation.GoToAuthPage();
    }
}