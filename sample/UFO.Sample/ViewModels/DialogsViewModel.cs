using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
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
			var result = await _ufoDialog.ShowConfirmDialogAsync("Information",
				"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat");
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
