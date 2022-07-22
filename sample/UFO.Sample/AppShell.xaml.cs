﻿using UFO.Sample.Pages;
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
	}
}
