using CommunityToolkit.Maui;
using UFO.UI.Dialogs;

namespace UFO.TestApp
{
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
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<SecondPage>();
			builder.Services.AddTransient<MainViewModel>();
			builder.Services.AddTransient<SecondPage>();
			builder.Services.AddTransient<SecondViewModel>();
			builder.Services.AddTransient<IDialog, Dialog>();

			return builder.Build();
		}
	}
}