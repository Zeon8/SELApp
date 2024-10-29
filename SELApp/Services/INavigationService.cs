using SELApp.Models;

namespace SELApp.Services
{
    public interface INavigationService
    {
        Task GoToAuthPage();
        Task GoToMainPage(User user);
    }
}
