using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages.Dialogs;

public partial class DialogsPage : BasePage
{
	public DialogsPage(DialogsViewModel dialogsViewModel)
	{
		InitializeComponent();
		BindingContext = dialogsViewModel;
	}
}