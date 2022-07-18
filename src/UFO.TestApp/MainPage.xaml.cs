namespace UFO.TestApp
{
	public partial class MainPage : ContentPage
	{
			private readonly MainViewModel _mainViewModel;
			public MainPage(MainViewModel mainViewModel)
			{
				InitializeComponent();
				_mainViewModel = mainViewModel;
				BindingContext = _mainViewModel;
			}

			protected override void OnAppearing()
			{
				base.OnAppearing();
				_mainViewModel.OnAppearing();
			}
	}
}