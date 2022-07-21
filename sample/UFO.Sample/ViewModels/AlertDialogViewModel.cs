using CommunityToolkit.Mvvm.Input;
using UFO.UI.Dialogs;
using UFO.UI.Dialogs.Configs;
using static UFO.Sample.Helpers.Utils;

namespace UFO.Sample.ViewModels
{
	public partial class AlertDialogViewModel : BaseViewModel
	{
		private readonly IUfoDialog _ufoDialog;

		public AlertDialogViewModel(IUfoDialog ufoDialog)
		{
			_ufoDialog = ufoDialog;
		}


		[RelayCommand]
		public async void OnAlertDialog()
		{
			await _ufoDialog.ShowAlertDialogAsync("Title", LoremImpsum);
		}

		[RelayCommand]
		public async void OnAlertDialogWithHeaderImage()
		{
			var config = new AlertDialogConfig
			{
				HeaderImageSource = new FileImageSource() { File = "headerimage.png" },
				HeaderImageHorizontalOptions = LayoutOptions.Start
			};

			await _ufoDialog.ShowAlertDialogAsync("Title", LoremImpsum, config: config);
		}

		[RelayCommand]
		public async void OnAlertDialogWithFontHeaderImage()
		{
			var config = new AlertDialogConfig
			{
				HeaderImageSource = new FontImageSource
				{
					FontFamily = MaterialDesignIcons,
					Color = Color.FromArgb("#7c54d4"),
					Size = 30,
					Glyph = "\U000f04d2",
				},
				HeaderImageHorizontalOptions = LayoutOptions.Start
			};

			await _ufoDialog.ShowAlertDialogAsync("Title", LoremImpsum, config: config);
		}
	}
}

