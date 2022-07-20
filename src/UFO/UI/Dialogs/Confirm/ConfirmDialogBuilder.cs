using UFO.UI.Dialogs.Configs;
using UFO.UI.Dialogs.Confirm;

namespace UFO.UI.Dialogs;

internal class ConfirmDialogBuilder : IDialogBuilder<ConfirmDialog, ConfirmDialogConfig>
{
    private ConfirmDialog dialog;
    private ConfirmDialogConfig config;
	
    public void Build(ConfirmDialog dialog, ConfirmDialogConfig config)
    {
        this.dialog = dialog;
        this.config = config;
		
        BuildHeader();
        BuildTitle();
        BuildDescription();
        BuildAction();
    }

    private void BuildHeader()
    {
        if (config.HeaderImageSource != null)
        {
            dialog.HeaderImage.Source = config.HeaderImageSource;
            dialog.HeaderImage.VerticalOptions = config.HeaderImageVerticalOptions;
            dialog.HeaderImage.HorizontalOptions = config.HeaderImageHorizontalOptions;
        }	
        else
        {
            dialog.HeaderImage.IsVisible = false;
        }
    }
	
    private void BuildTitle()
    {
        dialog.TitleLabel.Text = config.Title;
        dialog.TitleLabel.TextColor = config.TitleFontColor;
        dialog.TitleLabel.FontSize = config.TitleFontSize;

        if (!string.IsNullOrEmpty(config.TitleFontFamily))
        {
            config.TitleLabel.FontFamily = config.TitleFontFamily;
        }
    }

    private static void BuildDescription()
    {
        if (!string.IsNullOrEmpty(config.Description))
        {
            dialog.DescriptionLabel.Text = config.Description;
            dialog.DescriptionLabel.TextColor = config.DescriptionFontColor;

            if (!string.IsNullOrEmpty(config.DescriptionFontFamily))
            {
                dialog.DescriptionLabel.FontFamily = config.DescriptionFontFamily;
            }
        }
        else
        {
            dialog.DescriptionLabel.IsVisible = false;
        }	
    }

    private static void BuildAction()
    {
        dialog.NegativeButton.BackgroundColor = config.NegativeButtonColor;
        dialog.NegativeButton.Text = config.NegativeButtonText;

        if (!string.IsNullOrEmpty(config.NegativeButtonFontFamily))
        {
            dialog.NegativeButton.FontFamily = config.NegativeButtonFontFamily;
        }

        dialog.NegativeButton.BorderColor = config.NegativeButtonBorderColor;
        dialog.NegativeButton.BorderWidth = config.NegativeButtonBorderWidth;
        dialog.NegativeButton.TextColor = config.NegativeButtonFontColor;

        dialog.PositiveButton.BackgroundColor = config.PositiveButtonColor;
        dialog.PositiveButton.Text = config.PositiveButtonText;

        if (!string.IsNullOrEmpty(config.PositiveButtonFontFamily))
        {
            dialog.PositiveButton.FontFamily = config.PositiveButtonFontFamily;
        }
        dialog.PositiveButton.BorderColor = config.NegativeButtonBorderColor;
        dialog.PositiveButton.BorderWidth = config.NegativeButtonBorderWidth;

        if (dialog.ShowDontAskAgain)
        {
            dialog.DontAskAgainCheckBox.Text = config.DontAskAgainText;
        }
        else
        {
            dialog.DontAskAgainCheckBox.IsVisible = false;
        }
    }
	
}