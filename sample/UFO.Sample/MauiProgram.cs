using CommunityToolkit.Maui;
using Maui.Plugins.PageResolver;
using UFO.Sample.Pages;
using UFO.Sample.Services;
using UFO.Sample.ViewModels;
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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<DialogsPage>();
		builder.Services.AddTransient<DialogsViewModel>();
		builder.Services.AddSingleton<IUfoDialog, UfoDialog>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.UsePageResolver();
		return builder.Build();
	}
}
