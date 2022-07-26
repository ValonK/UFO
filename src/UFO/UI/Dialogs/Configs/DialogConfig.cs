using UFO.Utilities;
using static UFO.Utilities.UfoColors;

namespace UFO.UI.Dialogs.Configs;

public abstract class DialogConfig
{
    public Color TitleFontColor { get; set; } = Colors.Black;

    public string TitleFontFamily { get; set; }

    public string Title { get; set; }

    public Color BackgroundColor { get; set; } = Colors.White;

    public float CornerRadius { get; set; } = UfoSizes.DefaultCornerRadius;

    public ImageSource IconSource { get; set; }

    public double IconHeight { get; set; } = 25;

    public double IconWidth { get; set; } = 25;

    public LayoutOptions IconHorizontalOptions { get; set; } = LayoutOptions.Center;

    public LayoutOptions IconVerticalOptions { get; set; } = LayoutOptions.Center;

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