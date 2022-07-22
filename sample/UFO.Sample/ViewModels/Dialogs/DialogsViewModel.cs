using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using UFO.Sample.Pages.Dialogs;
using UFO.UI.Dialogs;

namespace UFO.Sample.ViewModels
{
	public partial class DialogsViewModel : BaseViewModel
	{
		private readonly IUfoDialog _ufoDialog;

		public DialogsViewModel(IUfoDialog ufoDialog)
		{
			_ufoDialog = ufoDialog;
		}

		[RelayCommand]
		private async Task ShowConfirmDialog()
		{
			await Shell.Current.GoToAsync(nameof(ConfirmDialogPage));
		}

		[RelayCommand]
		private async Task ShowAlertDialog()
		{
			await Shell.Current.GoToAsync(nameof(AlertDialogPage));
		}

		public override void OnAppearing()
		{
			base.OnAppearing();
		}

		public override void OnDisappearing()
		{
			base.OnDisappearing();
		}
	}
}
