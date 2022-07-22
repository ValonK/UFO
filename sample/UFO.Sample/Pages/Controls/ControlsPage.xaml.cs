using UFO.Sample.ViewModels.Controls;

namespace UFO.Sample.Pages.Controls;

public partial class ControlsPage : ContentPage
{
	public ControlsPage(ControlsViewModel controlsViewModel) 
	{
		InitializeComponent();
		BindingContext = controlsViewModel;
	}
}