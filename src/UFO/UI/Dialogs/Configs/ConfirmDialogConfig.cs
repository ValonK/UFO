using UFO.Utilities;
using static UFO.Utilities.UfoColors;

namespace UFO.UI.Dialogs.Configs;

public sealed class ConfirmDialogConfig : DialogConfig
{
    public DialogButtonConfig DeclineButtonConfig { get; set; } = new DialogButtonConfig
    {
        Background = new SolidColorBrush(Colors.White),
        TextColor = UfoDeclineButtonFontColor,
        BorderWidth = UfoSizes.DefaultButtonBorderWidth,
        BorderColor = UfoDeclineButtonBorderColor
    };
}