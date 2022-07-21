using static UFO.Utilities.UfoColors;

namespace UFO.UI.Dialogs.Configs;

public abstract class DialogConfig
{
    public Color TitleFontColor { get; set; } = Colors.Black;

    public string TitleFontFamily { get; set; }

    public string Title { get; set; }

    public Color BackgroundColor { get; set; } = Colors.White;

    public ImageSource HeaderImageSource { get; set; }

    public LayoutOptions HeaderImageHorizontalOptions { get; set; } = LayoutOptions.Center;

    public LayoutOptions HeaderImageVerticalOptions { get; set; } = LayoutOptions.Center;

    public string Description { get; set; }

    public TextAlignment TitleHorizontalTextAlignment { get; set; } = TextAlignment.Center;

    public TextAlignment TitleVerticalTextAlignment { get; set; } = TextAlignment.Center;

    public double TitleFontSize { get; set; } = 20;

    public TextAlignment DescriptionHorizontalTextAlignment { get; set; } = TextAlignment.Center;

    public TextAlignment DescriptionVerticalTextAlignment { get; set; } = TextAlignment.Center;

    public double DescriptionFontSize { get; set; }

    public string DescriptionFontFamily { get; set; }

    public Color DescriptionFontColor { get; set; } = Color.FromArgb("#8f949a");
}