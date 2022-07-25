using CommunityToolkit.Mvvm.Input;
using UFO.UI.Dialogs;
using UFO.UI.Dialogs.Configs;
using static UFO.Sample.Helpers.Utils;

namespace UFO.Sample.ViewModels;

public partial class ConfirmDialogViewModel : BaseViewModel
{
	private readonly IUfoDialog _ufoDialog;

	public ConfirmDialogViewModel(IUfoDialog ufoDialog)
	{
		_ufoDialog = ufoDialog;
	}


	[RelayCommand]
	public async void OnConfirmDialog()
	{
		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum);
	}

	[RelayCommand]
	public async void OnConfirmDialogWithDontAskAgain()
	{
		var confirmDialogConfig = new ConfirmDialogConfig
		{
			ShowCheckBox = true
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}

	[RelayCommand]
	public async void OnConfirmDialogWithHeaderImage()
	{
		var confirmDialogConfig = new ConfirmDialogConfig
		{
			IconSource = new FileImageSource() { File = "headerimage.png" },
			IconHorizontalOptions = LayoutOptions.Start,
			IconHeight = 30,
			IconWidth = 30
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}

	[RelayCommand]
	public async void OnConfirmDialogWithFontHeaderImage()
	{
		var confirmDialogConfig = new ConfirmDialogConfig
		{
			IconSource = new FontImageSource { 
				FontFamily = MaterialDesignIcons, 
				Color = Color.FromArgb("#7c54d4"),
				Size = 30,
				Glyph = "\U000f04d2",
			},
			IconHorizontalOptions = LayoutOptions.Start
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}
}

