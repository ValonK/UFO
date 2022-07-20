using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages;

public partial class DialogsPage : BasePage
{
	public DialogsPage(DialogsViewModel dialogsViewModel)
	{
		InitializeComponent();
		BindingContext = dialogsViewModel;
	}
}