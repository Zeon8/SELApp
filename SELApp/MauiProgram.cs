using Microsoft.Extensions.Logging;
using Plugin.FirebasePushNotifications;
using SELApp.Services;
using SELApp.ViewModels;
using SELApp.Views;

namespace SELApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseFirebasePushNotifications()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureServices();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton(new HttpClient()
            {
                BaseAddress = new Uri(Globals.ServerAdress)
            });
            builder.Services.AddSingleton<HttpAuthService>();
            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddSingleton<StorageService>();

            builder.Services.AddTransient<AuthPageViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AuthPage>();

            return builder;
        }
    }
}
