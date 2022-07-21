using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public partial class ConfirmDialog : Dialog, IAwaitableResultDialog<ConfirmDialogResult>
{
	private ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
	{
		InitializeComponent();
		ConfigureDialog(confirmDialogConfig);
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

		var dialog = new ConfirmDialog(confirmDialogConfig)
		{
			TaskCompletionSource = new TaskCompletionSource<ConfirmDialogResult>()
		};

		if (Application.Current == null)
		{
			throw new InvalidOperationException("Application.Current cannot be null");
		}

		await MainPage.ShowPopupAsync(dialog);
		return await dialog.TaskCompletionSource.Task;
	}

	private void ConfigureDialog(ConfirmDialogConfig confirmDialogConfig)
	{
		DialogContainer.CornerRadius = 15;
		DialogContainer.BackgroundColor = confirmDialogConfig.BackgroundColor;

		if (confirmDialogConfig.HeaderImageSource != null)
		{
			HeaderImage.Source = confirmDialogConfig.HeaderImageSource;
			HeaderImage.VerticalOptions = confirmDialogConfig.HeaderImageVerticalOptions;
			HeaderImage.HorizontalOptions = confirmDialogConfig.HeaderImageHorizontalOptions;
		}

		TitleLabel.Text = confirmDialogConfig.Title;
		TitleLabel.TextColor = confirmDialogConfig.TitleFontColor;
		TitleLabel.FontSize = confirmDialogConfig.TitleFontSize;
		TitleLabel.FontFamily = confirmDialogConfig.TitleFontFamily;
		
		DescriptionLabel.Text = confirmDialogConfig.Description;
		DescriptionLabel.TextColor = confirmDialogConfig.DescriptionFontColor;
		DescriptionLabel.FontFamily = confirmDialogConfig.DescriptionFontFamily;

		DeclineButton.Background = confirmDialogConfig.DeclineButtonConfig.Background;
		DeclineButton.Text = confirmDialogConfig.DeclineButtonConfig.Text;
		DeclineButton.FontFamily = confirmDialogConfig.DeclineButtonConfig.FontFamily;
		DeclineButton.BorderColor = confirmDialogConfig.DeclineButtonConfig.BorderColor;
		DeclineButton.BorderWidth = confirmDialogConfig.DeclineButtonConfig.BorderWidth;
		DeclineButton.TextColor = confirmDialogConfig.DeclineButtonConfig.TextColor;
		DeclineButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult(new(DontAskAgainCheckBox.IsChecked, false));
		};

		ConfirmButton.Background = confirmDialogConfig.ConfirmButtonConfig.Background;
		ConfirmButton.Text = confirmDialogConfig.ConfirmButtonConfig.Text;
		ConfirmButton.FontFamily = confirmDialogConfig.ConfirmButtonConfig.FontFamily;
		ConfirmButton.BorderColor = confirmDialogConfig.ConfirmButtonConfig.BorderColor;
		ConfirmButton.BorderWidth = confirmDialogConfig.ConfirmButtonConfig.BorderWidth;
		ConfirmButton.TextColor = confirmDialogConfig.ConfirmButtonConfig.TextColor;
		ConfirmButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult(new(DontAskAgainCheckBox.IsChecked, true));
		};

		if (confirmDialogConfig.ShowDontAskAgain)
		{
			DontAskAgainCheckBox.Text = confirmDialogConfig.DontAskAgainText;
			DontAskAgainCheckBox.TextColor = confirmDialogConfig.DontAskAgainFontColor;
		}
		else
		{
			DontAskAgainCheckBox.IsVisible = false;
		}
	}
}