using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public partial class ConfirmDialog : Dialog, IAwaitableResultDialog<ConfirmDialogResult>
{
	private readonly ConfirmDialogConfig _confirmDialogConfig;

	internal ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
	{
		InitializeComponent();
		_confirmDialogConfig = confirmDialogConfig;
		
		ConfigureDialog();
	}

	public TaskCompletionSource<ConfirmDialogResult> TaskCompletionSource { get; set; }

	public static async Task<ConfirmDialogResult> ShowAsync(string title, string description = "", string confirmText = "Ok",
		string declineText = "Cancel", ConfirmDialogConfig confirmDialogConfig = null)
	{
		confirmDialogConfig ??= new ConfirmDialogConfig();
		confirmDialogConfig.ConfirmButtonConfig ??= new DialogButtonConfig();
		confirmDialogConfig.ConfirmButtonConfig.Text = confirmText;
		confirmDialogConfig.DeclineButtonConfig ??= new DialogButtonConfig();
		confirmDialogConfig.DeclineButtonConfig.Text = declineText;
		confirmDialogConfig.Title = title;
		confirmDialogConfig.Description = description;

		var dialog = new ConfirmDialog(confirmDialogConfig) { TaskCompletionSource = new() };
		await MainPage.ShowPopupAsync(dialog);
		return await dialog.TaskCompletionSource.Task;
	}

	private void ConfigureDialog()
	{
		DialogContainer.CornerRadius = _confirmDialogConfig.CornerRadius;
		DialogContainer.BackgroundColor = _confirmDialogConfig.BackgroundColor;

		if (_confirmDialogConfig.IconSource != null)
		{
			HeaderImage.Source = _confirmDialogConfig.IconSource;
			HeaderImage.VerticalOptions = _confirmDialogConfig.IconVerticalOptions;
			HeaderImage.HorizontalOptions = _confirmDialogConfig.IconHorizontalOptions;
			HeaderImage.HeightRequest = _confirmDialogConfig.IconHeight;
			HeaderImage.WidthRequest= _confirmDialogConfig.IconWidth;
		}

		TitleLabel.Text = _confirmDialogConfig.Title;
		TitleLabel.TextColor = _confirmDialogConfig.TitleFontColor;
		TitleLabel.FontSize = _confirmDialogConfig.TitleFontSize;
		TitleLabel.FontFamily = _confirmDialogConfig.TitleFontFamily;
		
		DescriptionLabel.Text = _confirmDialogConfig.Description;
		DescriptionLabel.TextColor = _confirmDialogConfig.DescriptionFontColor;
		DescriptionLabel.FontFamily = _confirmDialogConfig.DescriptionFontFamily;

		DeclineButton.Background = _confirmDialogConfig.DeclineButtonConfig.Background;
		DeclineButton.Text = _confirmDialogConfig.DeclineButtonConfig.Text;
		DeclineButton.FontFamily = _confirmDialogConfig.DeclineButtonConfig.FontFamily;
		DeclineButton.BorderColor = _confirmDialogConfig.DeclineButtonConfig.BorderColor;
		DeclineButton.BorderWidth = _confirmDialogConfig.DeclineButtonConfig.BorderWidth;
		DeclineButton.TextColor = _confirmDialogConfig.DeclineButtonConfig.TextColor;
		DeclineButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult(new(CheckBox.IsChecked, false));
		};

		ConfirmButton.Background = _confirmDialogConfig.ConfirmButtonConfig.Background;
		ConfirmButton.Text = _confirmDialogConfig.ConfirmButtonConfig.Text;
		ConfirmButton.FontFamily = _confirmDialogConfig.ConfirmButtonConfig.FontFamily;
		ConfirmButton.BorderColor = _confirmDialogConfig.ConfirmButtonConfig.BorderColor;
		ConfirmButton.BorderWidth = _confirmDialogConfig.ConfirmButtonConfig.BorderWidth;
		ConfirmButton.TextColor = _confirmDialogConfig.ConfirmButtonConfig.TextColor;
		ConfirmButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult(new(CheckBox.IsChecked, true));
		};

		if (_confirmDialogConfig.ShowCheckBox)
		{
			CheckBox.Text = _confirmDialogConfig.CheckBoxText;
			CheckBox.TextColor = _confirmDialogConfig.CheckBoxTextColor;
		}
		else
		{
			CheckBox.IsVisible = false;
		}
	}

	protected override void OnDismissedByTappingOutsideOfPopup()
	{
		if (_confirmDialogConfig.CloseWhenBackgroundIsClicked) TaskCompletionSource.TrySetResult(new(CheckBox.IsChecked, false));
	}
}