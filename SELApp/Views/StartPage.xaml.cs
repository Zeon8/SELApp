using System.Text.Json;
using SELApp.Models;
using SELApp.Services;

namespace SELApp.Views;

public partial class StartPage : ContentPage
{
    private readonly INavigationService _navigation;
    private readonly ISessionStorageService _sessionStorage;

    public StartPage(INavigationService navigationService, ISessionStorageService sessionStorage)
    {
        InitializeComponent();
        _navigation = navigationService;
        _sessionStorage = sessionStorage;

        Task.Run(LoadPage);
    }

    private async Task LoadPage()
    {
        User? user = await _sessionStorage.Load();
        if(user is not null)
            await _navigation.GoToMainPage(user);
        else
            await _navigation.GoToAuthPage();
    }
}