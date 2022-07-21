using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages.Dialogs;

public partial class AlertDialogPage 
{
	public AlertDialogPage(AlertDialogViewModel alertDialogViewModel)
	{
		InitializeComponent();
		BindingContext = alertDialogViewModel;
	}
}