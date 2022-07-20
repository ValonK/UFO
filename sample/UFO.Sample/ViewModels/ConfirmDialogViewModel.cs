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
			ShowDontAskAgain = true
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}

	[RelayCommand]
	public async void OnConfirmDialogWithHeaderImage()
	{
		var confirmDialogConfig = new ConfirmDialogConfig
		{
			HeaderImageSource = new FileImageSource() { File = "headerimage.png" },
			HeaderImageHorizontalOptions = LayoutOptions.Start 
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}

	[RelayCommand]
	public async void OnConfirmDialogWithFontHeaderImage()
	{
		var confirmDialogConfig = new ConfirmDialogConfig
		{
			HeaderImageSource = new FontImageSource { 
				FontFamily = MaterialDesignIcons, 
				Color = Color.FromArgb("#7c54d4"),
				Size = 30,
				Glyph = "\U000f04d2",
			},
			HeaderImageHorizontalOptions = LayoutOptions.Start
		};

		var result = await _ufoDialog.ShowConfirmDialogAsync("Title", LoremImpsum, config: confirmDialogConfig);
	}
}

