﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.FirebasePushNotifications;
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

        private readonly SessionStorageService _sessionStorage;
        private readonly NavigationService _navigation;
        private readonly IFirebasePushNotification _pushNotification;

        public MainPageViewModel(SessionStorageService sessionStorage, 
            NavigationService navigation, 
            IFirebasePushNotification pushNotification)
        {
            _sessionStorage = sessionStorage;
            _navigation = navigation;
            _pushNotification = pushNotification;
        }

        [RelayCommand]
        private async Task Signout()
        {
            _sessionStorage.Delete();
            await _pushNotification.UnregisterForPushNotificationsAsync();
            await _navigation.GoToAuthPage();
        }
    }
}
