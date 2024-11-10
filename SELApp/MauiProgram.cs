using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Plugin.FirebasePushNotifications;
using SELApp.Services;
using SELApp.ViewModels;
using SELApp.Views;
using System.Reflection;

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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("SELApp.Resources.Raw.appsettings.development.json")
                ?? throw new InvalidOperationException("Failed to load app configuration.");
            
            var configuration = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(configuration);

            builder.ConfigureServices();
            return builder.Build();
        }

        private static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton(new HttpClient()
            {
                BaseAddress = new Uri(builder.Configuration.GetRequiredSection("ServerAdress").Value!)
            });

            builder.Services.AddSingleton<HttpAuthService>();
            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddSingleton<SessionStorageService>();

            builder.Services.AddTransient<AuthPageViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AuthPage>();

            return builder;
        }
    }
}
