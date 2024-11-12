using SELApp.ViewModels;

namespace SELApp.Views;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(SchedulePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        Loaded += SchedulePage_Loaded;
	}

    private void SchedulePage_Loaded(object? sender, EventArgs e)
    {
		var viewModel = (SchedulePageViewModel)BindingContext;
		Task.Run(viewModel.Load);
    }
}