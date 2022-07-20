using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages;

public partial class MainPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

}

