using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages.Dialogs;

public partial class ConfirmDialogPage
{
	public ConfirmDialogPage(ConfirmDialogViewModel confirmDialogViewModel)
	{
		InitializeComponent();
		BindingContext = confirmDialogViewModel;
	}
}