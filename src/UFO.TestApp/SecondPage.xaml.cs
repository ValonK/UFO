namespace UFO.TestApp
{
	public partial class SecondPage : ContentPage
	{
		private readonly SecondViewModel _secondViewModel;
		public SecondPage(SecondViewModel secondViewModel)
		{
			InitializeComponent();
			_secondViewModel = secondViewModel;
			BindingContext = _secondViewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_secondViewModel.OnAppearing();
		}
	}
}