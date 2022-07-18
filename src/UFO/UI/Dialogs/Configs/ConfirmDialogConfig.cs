namespace UFO.UI.Dialogs.Configs;

public abstract class ConfirmDialogConfig : BaseConfig
{
    public Color TitleColor { get; set; }

    public Color DescriptionColor { get; set; }
    
    public Color PositiveButtonColor { get; set; }

    public Color NegativeButtonColor { get; set; }
}