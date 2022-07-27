using UFO.Sample.Pages.Controls;
using UFO.Sample.Pages.Controls.Cards;
using UFO.Sample.Pages.Dialogs;

namespace UFO.Sample;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DialogsPage), typeof(DialogsPage));
		Routing.RegisterRoute(nameof(ConfirmDialogPage), typeof(ConfirmDialogPage));
		Routing.RegisterRoute(nameof(AlertDialogPage), typeof(AlertDialogPage));
		Routing.RegisterRoute(nameof(ControlsPage), typeof(ControlsPage));
		Routing.RegisterRoute(nameof(CardsPage), typeof(CardsPage));
		Routing.RegisterRoute(nameof(ChipsPage), typeof(ChipsPage));
		Routing.RegisterRoute(nameof(SelectionControlsPage), typeof(SelectionControlsPage));
		Routing.RegisterRoute(nameof(ActionCardPage), typeof(ActionCardPage));
		Routing.RegisterRoute(nameof(AvatarCardPage), typeof(AvatarCardPage));
		Routing.RegisterRoute(nameof(ParallaxCardPage), typeof(ParallaxCardPage));
		Routing.RegisterRoute(nameof(SettingsCardPage), typeof(SettingsCardPage));
	}
}
