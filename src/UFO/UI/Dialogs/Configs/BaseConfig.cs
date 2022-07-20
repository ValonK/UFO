namespace UFO.UI.Dialogs.Configs;

public abstract class BaseConfig
{
    public Color BackgroundColor { get; set; } = Colors.White;
    
    public ImageSource HeaderImageSource { get; set; }
    
    public LayoutOptions HeaderImageHorizontalOptions { get; set; } = LayoutOptions.Center;
    public LayoutOptions HeaderImageVerticalOptions { get; set; } = LayoutOptions.Center;

    public bool ShowDontAskAgain { get; set; } = false;

    public string DontAskAgainText { get; set; } = "Dont ask again";

    public Color DontAskAgainFontColor { get; set; } = Color.FromArgb("#808692");
}