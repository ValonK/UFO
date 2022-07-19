using System.Diagnostics;
using System.Windows.Input;
using UFO.UI.Dialogs;

namespace UFO.TestApp
{
	public class SecondViewModel : BaseViewModel
	{
		private readonly IDialog _dialogService;
		private bool _isChecked;

		public SecondViewModel(IDialog dialogService)
		{
			_dialogService = dialogService;
			TestCommand = new Command(OnTest);
			CheckedChangedCommand = new Command<bool>(OnCheckedChanged); 
		}

		private void OnCheckedChanged(bool obj)
		{
		}

		private void OnTest(object obj)
		{
			IsChecked = !IsChecked;
		}

		public ICommand TestCommand { get; set; }
		public Command<bool> CheckedChangedCommand { get; set; }


		public string Text { get; set; }

		public bool IsChecked
		{
			get => _isChecked;
			set
			{
				_isChecked = value;
				OnPropertyChanged(nameof(IsChecked));
			}
		}

		public async void OnAppearing()
		{
			// await _dialogService.ShowConfirmDialogAsync("This is some Title", "This is a long description text, this is some long text This is a long description text, this is some long text This is a long description text, this is some long text This is a long description text, this is some long text");
		}
	}
}
