using CommunityToolkit.Maui;
using UFO.Sample.Pages;
using UFO.Sample.Pages.Controls;
using UFO.Sample.Pages.Controls.Cards;
using UFO.Sample.Pages.Dialogs;
using UFO.Sample.ViewModels;
using UFO.Sample.ViewModels.Controls;
using UFO.UI.Dialogs;

namespace UFO.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<DialogsPage>();
		builder.Services.AddTransient<DialogsViewModel>();
		builder.Services.AddTransient<ConfirmDialogPage>();
		builder.Services.AddTransient<ConfirmDialogViewModel>();
		builder.Services.AddTransient<AlertDialogPage>();
		builder.Services.AddTransient<AlertDialogViewModel>();
		builder.Services.AddTransient<ControlsPage>();
		builder.Services.AddTransient<ControlsViewModel>();
		builder.Services.AddTransient<CardsPage>();
		builder.Services.AddTransient<CardsViewModel>();
		builder.Services.AddTransient<ChipsPage>();
		builder.Services.AddTransient<ChipsViewModel>();
		builder.Services.AddSingleton<IUfoDialog, UfoDialog>();
		return builder.Build();
	}
}
