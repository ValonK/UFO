using UFO.UI.Dialogs;

namespace UFO.TestApp
{
	public class SecondViewModel
	{
		private readonly IDialog _dialogService;

		public SecondViewModel(IDialog dialogService)
		{
			_dialogService = dialogService;
		}
		
		
		public async void OnAppearing()
		{
			await _dialogService.ShowConfirmDialogAsync("hi", "desc");
		}
	}
}
