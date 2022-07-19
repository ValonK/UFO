namespace UFO.UI.Dialogs.Configs;

public abstract class BaseConfig
{
    public float CornerRadius { get; set; } = 10;

    public Color BackgroundColor { get; set; } = Colors.White;

    public bool HasShadow { get; set; } = false;
    
    public ImageSource HeaderImageSource { get; set; }
    
    public LayoutOptions HeaderImageHorizontalOptions { get; set; } = LayoutOptions.Center;
    public LayoutOptions HeaderImageVerticalOptions { get; set; } = LayoutOptions.Center;

    public bool ShowDontAskAgain { get; set; } = false;
}