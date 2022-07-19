namespace UFO.UI.Dialogs.Configs;

public class ConfirmDialogConfig : BaseConfig
{
    private static readonly Color DefaultPositiveButtonColor = Color.FromArgb("#7c54d4");
    private static readonly Color DefaultNegativeButtonColor = Colors.White;
    private static readonly Color DefaultFontColor = Colors.Black;
    private const double DefaultButtonBorderWidth = 1;

    public Color TitleFontColor { get; set; } = DefaultFontColor;
    
    public string TitleFontFamily { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public TextAlignment TitleHorizontalTextAlignment { get; set; } = TextAlignment.Center;
    
    public TextAlignment TitleVerticalTextAlignment { get; set; } = TextAlignment.Center;

    public double TitleFontSize { get; set; } = 20;
    
    public TextAlignment DescriptionHorizontalTextAlignment { get; set; } = TextAlignment.Center;
    
    public TextAlignment DescriptionVerticalTextAlignment { get; set; } = TextAlignment.Center;
    public double DescriptionFontSize { get; set; }
    
    public string DescriptionFontFamily { get; set; }
    
    public Color DescriptionFontColor { get; set; } = Color.FromArgb("#8f949a");

    public string PositiveButtonText { get; set; }
    public Color PositiveButtonColor { get; set; } = DefaultPositiveButtonColor;
    
    public Color PositiveButtonFontColor { get; set; } = Colors.White;

    public double PositiveButtonFontSize { get; set; }
    
    public Color PositiveButtonBorderColor { get; set; } = DefaultPositiveButtonColor;

    public double PositiveButtonBorderWidth { get; set; } = DefaultButtonBorderWidth;

    public string PositiveButtonFontFamily { get; set; }

    public string NegativeButtonText { get; set; }
    public string NegativeButtonFontFamily { get; set; }

	public double NegativeButtonFontSize { get; set; }
    
    public Color NegativeButtonColor { get; set; } = DefaultNegativeButtonColor;
    
    public Color NegativeButtonFontColor { get; set; } = DefaultFontColor;
    
    public double NegativeButtonBorderWidth { get; set; } = DefaultButtonBorderWidth;

    public Color NegativeButtonBorderColor { get; set; } = Color.FromArgb("#e6e8ec");
}