using UFO.Utilities;
using static UFO.Utilities.UfoColors;

namespace UFO.UI.Dialogs.Configs
{
    public sealed class AlertDialogConfig : DialogConfig
	{
		public DialogButtonConfig ConfirmButtonConfig { get; set; } = new DialogButtonConfig
		{
			Background = new SolidColorBrush(UfoPrimaryColor),
			TextColor = Colors.White,
			BorderWidth = UfoSizes.DefaultButtonBorderWidth,
			BorderColor = UfoPrimaryColor
		};
	}
}
