using UFO.Utilities;
using static UFO.Utilities.UfoColors;

namespace UFO.UI.Dialogs.Configs;

public sealed class ConfirmDialogConfig : DialogConfig
{
    public DialogButtonConfig ConfirmButtonConfig { get; set; } = new DialogButtonConfig
    {
        Background = new SolidColorBrush(UfoPrimaryColor),
        TextColor = Colors.White,
        BorderWidth = UfoSizes.DefaultButtonBorderWidth,
        BorderColor = UfoPrimaryColor
    };

    public DialogButtonConfig DeclineButtonConfig { get; set; } = new DialogButtonConfig
    {
        Background = new SolidColorBrush(Colors.White),
        TextColor = UfoDeclineButtonFontColor,
        BorderWidth = UfoSizes.DefaultButtonBorderWidth,
        BorderColor = UfoDecloneButtonBorderColor
    };

	public Color DontAskAgainFontColor { get; set; } = Color.FromArgb("#808692");

	public bool ShowDontAskAgain { get; set; } = false;

	public string DontAskAgainText { get; set; } = "Dont ask again";
}