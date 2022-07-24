using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public partial class AlertDialog : Dialog, IAwaitableDialog
{
	internal AlertDialog(AlertDialogConfig alertDialogConfig)
	{
		InitializeComponent();
		ConfigureDialog(alertDialogConfig);
	}

	public TaskCompletionSource TaskCompletionSource { get; set; }
	
	public static async Task ShowAsync(string title, string description = "", string confirmButton = "", AlertDialogConfig alertDialogConfig = null)
	{
		alertDialogConfig ??= new AlertDialogConfig();
		alertDialogConfig.ConfirmButtonConfig ??= new DialogButtonConfig();
		alertDialogConfig.ConfirmButtonConfig.Text = confirmButton;
		alertDialogConfig.Title = title;
		alertDialogConfig.Description = description;

		var dialog = new AlertDialog(alertDialogConfig) { TaskCompletionSource = new() };
		
		if (Application.Current == null)
		{
			throw new InvalidOperationException("Application.Current cannot be null");
		}

		await MainPage.ShowPopupAsync(dialog);
		await dialog.TaskCompletionSource.Task;
	}

	private void ConfigureDialog(AlertDialogConfig alertDialogConfig)
	{
		DialogContainer.CornerRadius = 15;
		DialogContainer.BackgroundColor = alertDialogConfig.BackgroundColor;

		if (alertDialogConfig.IconSource != null)
		{
			HeaderImage.Source = alertDialogConfig.IconSource;
			HeaderImage.VerticalOptions = alertDialogConfig.IconVerticalOptions;
			HeaderImage.HorizontalOptions = alertDialogConfig.IconHorizontalOptions;
			HeaderImage.HeightRequest = alertDialogConfig.IconHeight;
			HeaderImage.WidthRequest = alertDialogConfig.IconWidth;
		}

		TitleLabel.Text = alertDialogConfig.Title;
		TitleLabel.TextColor = alertDialogConfig.TitleFontColor;
		TitleLabel.FontSize = alertDialogConfig.TitleFontSize;
		TitleLabel.FontFamily = alertDialogConfig.TitleFontFamily;

		DescriptionLabel.Text = alertDialogConfig.Description;
		DescriptionLabel.TextColor = alertDialogConfig.DescriptionFontColor;
		DescriptionLabel.FontFamily = alertDialogConfig.DescriptionFontFamily;

		PositiveButton.Background = alertDialogConfig.ConfirmButtonConfig.Background;
		PositiveButton.Text = alertDialogConfig.ConfirmButtonConfig.Text;
		PositiveButton.FontFamily = alertDialogConfig.ConfirmButtonConfig.FontFamily;
		PositiveButton.BorderColor = alertDialogConfig.ConfirmButtonConfig.BorderColor;
		PositiveButton.BorderWidth = alertDialogConfig.ConfirmButtonConfig.BorderWidth;
		PositiveButton.TextColor = alertDialogConfig.ConfirmButtonConfig.TextColor;
		PositiveButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult();
		};
	}
}