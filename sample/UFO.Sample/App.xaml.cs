using UFO.Sample.Pages;

namespace UFO.Sample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
