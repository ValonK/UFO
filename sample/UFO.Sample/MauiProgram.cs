using CommunityToolkit.Maui;
using UFO.Sample.Pages;
using UFO.Sample.Pages.Controls;
using UFO.Sample.Pages.Controls.Cards;
using UFO.Sample.Pages.Dialogs;
using UFO.Sample.ViewModels;
using UFO.Sample.ViewModels.Controls;
using UFO.Sample.ViewModels.Controls.Cards;
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
		
		RegisterControls(builder.Services);
		RegisterDialogs(builder.Services);
		RegisterCards(builder.Services);
		
		return builder.Build();
	}

	private static void RegisterCards(IServiceCollection services)
	{
		services.AddTransient<CardsPage>();
		services.AddTransient<CardsViewModel>();
		services.AddTransient<ActionCardPage>();
		services.AddTransient<ActionsCardViewModel>();
		services.AddTransient<AvatarCardPage>();
		services.AddTransient<AvatarCardViewModel>();
		services.AddTransient<ParallaxCardPage>();
		services.AddTransient<ParallaxCardViewModel>();
		services.AddTransient<SettingsCardPage>();
		services.AddTransient<SettingsCardViewModel>();
	}

	private static void RegisterControls(IServiceCollection services)
	{
		services.AddTransient<ControlsPage>();
		services.AddTransient<ControlsViewModel>();
		services.AddTransient<ChipsPage>();
		services.AddTransient<ChipsViewModel>();
		services.AddTransient<SelectionControlsPage>();
		services.AddTransient<SelectionControlsViewModel>();
	}
	
	private static void RegisterDialogs(IServiceCollection services)
	{
		services.AddTransient<DialogsPage>();
		services.AddTransient<DialogsViewModel>();
		services.AddTransient<ConfirmDialogPage>();
		services.AddTransient<ConfirmDialogViewModel>();
		services.AddTransient<AlertDialogPage>();
		services.AddTransient<AlertDialogViewModel>();
		services.AddSingleton<IUfoDialog, UfoDialog>();
	}
}
