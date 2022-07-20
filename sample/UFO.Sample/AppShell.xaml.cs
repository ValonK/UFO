using UFO.Sample.Pages;
using UFO.Sample.Pages.Dialogs;

namespace UFO.Sample;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DialogsPage), typeof(DialogsPage));
		Routing.RegisterRoute(nameof(ConfirmDialogPage), typeof(ConfirmDialogPage));
	}
}
