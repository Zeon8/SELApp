using SELApp.ViewModels;

namespace SELApp.Views;

public partial class AuthPage : ContentPage
{
	public AuthPage(AuthPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}