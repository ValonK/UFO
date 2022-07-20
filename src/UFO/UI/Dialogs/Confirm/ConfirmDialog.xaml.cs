using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs.Confirm;

public partial class ConfirmDialog : BaseDialog, IAwaitableDialog<ConfirmDialogResult>
{
	private ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
	{
		InitializeComponent();
		ConfigureDialog(confirmDialogConfig);
	}

	public TaskCompletionSource<ConfirmDialogResult> TaskCompletionSource { get; set; }

	public static async Task<ConfirmDialogResult> ShowAsync(string title, string description, string positiveButton = "Ok",
		string negativeButton = "Cancel", ConfirmDialogConfig confirmDialogConfig = null)
	{
		confirmDialogConfig ??= new ConfirmDialogConfig();
		confirmDialogConfig.PositiveButtonText = positiveButton;
		confirmDialogConfig.NegativeButtonText = negativeButton;
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

		NegativeButton.BackgroundColor = confirmDialogConfig.NegativeButtonColor;
		NegativeButton.Text = confirmDialogConfig.NegativeButtonText;
		NegativeButton.FontFamily = confirmDialogConfig.NegativeButtonFontFamily;
		NegativeButton.BorderColor = confirmDialogConfig.NegativeButtonBorderColor;
		NegativeButton.BorderWidth = confirmDialogConfig.NegativeButtonBorderWidth;
		NegativeButton.TextColor = confirmDialogConfig.NegativeButtonFontColor;
		NegativeButton.Clicked += (sender, args) =>
		{
			OnClosed(null, false);
			TaskCompletionSource.TrySetResult(new(DontAskAgainCheckBox.IsChecked, false));
		};

		PositiveButton.BackgroundColor = confirmDialogConfig.PositiveButtonColor;
		PositiveButton.Text = confirmDialogConfig.PositiveButtonText;
		PositiveButton.FontFamily = confirmDialogConfig.PositiveButtonFontFamily;
		PositiveButton.BorderColor = confirmDialogConfig.NegativeButtonBorderColor;
		PositiveButton.BorderWidth = confirmDialogConfig.NegativeButtonBorderWidth;
		PositiveButton.TextColor = confirmDialogConfig.PositiveButtonFontColor;
		PositiveButton.Clicked += (sender, args) =>
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