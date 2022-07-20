using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages.Dialogs;

public partial class ConfirmDialogPage : ContentPage
{
	public ConfirmDialogPage(ConfirmDialogViewModel confirmDialogViewModel)
	{
		InitializeComponent();
		BindingContext = confirmDialogViewModel;
	}
}