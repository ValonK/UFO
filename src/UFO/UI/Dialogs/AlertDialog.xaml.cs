using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public partial class AlertDialog : Dialog, IAwaitableDialog
{
	private readonly AlertDialogConfig _alertDialogConfig;
	
	internal AlertDialog(AlertDialogConfig alertDialogConfig)
	{
		InitializeComponent();
		_alertDialogConfig = alertDialogConfig;

		ConfigureDialog();
	}

	public TaskCompletionSource TaskCompletionSource { get; set; }
	
	public static async Task ShowAsync(string title, string description = "", 
		string confirmButton = "", AlertDialogConfig alertDialogConfig = null)
	{
		alertDialogConfig ??= new AlertDialogConfig();
		alertDialogConfig.ConfirmButtonConfig ??= new DialogButtonConfig();
		alertDialogConfig.ConfirmButtonConfig.Text = confirmButton;
		alertDialogConfig.Title = title;
		alertDialogConfig.Description = description;

		var dialog = new AlertDialog(alertDialogConfig) { TaskCompletionSource = new() };
		await MainPage.ShowPopupAsync(dialog);
		await dialog.TaskCompletionSource.Task;
	}

	private void ConfigureDialog()
	{
		DialogContainer.CornerRadius = _alertDialogConfig.CornerRadius;
		DialogContainer.BackgroundColor = _alertDialogConfig.BackgroundColor;

		if (_alertDialogConfig.IconSource != null)
		{
			HeaderImage.Source = _alertDialogConfig.IconSource;
			HeaderImage.VerticalOptions = _alertDialogConfig.IconVerticalOptions;
			HeaderImage.HorizontalOptions = _alertDialogConfig.IconHorizontalOptions;
			HeaderImage.HeightRequest = _alertDialogConfig.IconHeight;
			HeaderImage.WidthRequest = _alertDialogConfig.IconWidth;
		}

		TitleLabel.Text = _alertDialogConfig.Title;
		TitleLabel.TextColor = _alertDialogConfig.TitleFontColor;
		TitleLabel.FontSize = _alertDialogConfig.TitleFontSize;
		TitleLabel.FontFamily = _alertDialogConfig.TitleFontFamily;

		DescriptionLabel.Text = _alertDialogConfig.Description;
		DescriptionLabel.TextColor = _alertDialogConfig.DescriptionFontColor;
		DescriptionLabel.FontFamily = _alertDialogConfig.DescriptionFontFamily;

		PositiveButton.Background = _alertDialogConfig.ConfirmButtonConfig.Background;
		PositiveButton.Text = _alertDialogConfig.ConfirmButtonConfig.Text;
		PositiveButton.FontFamily = _alertDialogConfig.ConfirmButtonConfig.FontFamily;
		PositiveButton.BorderColor = _alertDialogConfig.ConfirmButtonConfig.BorderColor;
		PositiveButton.BorderWidth = _alertDialogConfig.ConfirmButtonConfig.BorderWidth;
		PositiveButton.TextColor = _alertDialogConfig.ConfirmButtonConfig.TextColor;
		PositiveButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult();
		};
	}

	protected override void OnDismissedByTappingOutsideOfPopup()
	{
		if (_alertDialogConfig.CloseWhenBackgroundIsClicked) TaskCompletionSource.TrySetResult();
	}
}