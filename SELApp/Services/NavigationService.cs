using SELApp.Models;

namespace SELApp.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToAuthPage()
        {
            return Shell.Current.GoToAsync(new ShellNavigationState("//Auth"));
        }

        public Task GoToMainPage(User user)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"user", user}
            };
            return Shell.Current.GoToAsync(new ShellNavigationState("//Main"), parameters);
        }
    }
}
