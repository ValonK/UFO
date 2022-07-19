using UFO.UI.Dialogs.Configs;

namespace UFO.Utilities.Builders;

internal abstract class LayoutBuilder
{
    public abstract View CreateView();
}

internal class ConfirmDialogLayoutBuilder : LayoutBuilder
{
    private readonly Frame _containerFrame;
    private readonly Grid _layoutGrid;
    private readonly ConfirmDialogConfig _confirmDialogConfig;
    private Grid _headerGrid;
    private Grid _titleGrid;
    private Grid _descriptionGrid;
    private Grid _actionGrid;
    
    private Button _positiveButton;
    private Button _negativeButton;
    
    public ConfirmDialogLayoutBuilder(ConfirmDialogConfig confirmDialogConfig)
    {
        _confirmDialogConfig = confirmDialogConfig;
        _containerFrame = new();
        _layoutGrid = new();

        CreateDialogContainer();
        CreateHeader();
        CreateTitle();
        CreateDescription();
        CreateActionButtons();
    }

    public Button PositiveButton => _positiveButton;
    public Button NegativeButton => _negativeButton;
    
    private void CreateDialogContainer()
    {
        _containerFrame.HeightRequest = 250;
        _containerFrame.WidthRequest = 300;
        _containerFrame.IsClippedToBounds = true;
        
        _containerFrame.CornerRadius = _confirmDialogConfig.CornerRadius;
        _containerFrame.BackgroundColor = _confirmDialogConfig.BackgroundColor;
        _containerFrame.HasShadow = _confirmDialogConfig.HasShadow;
        
        _layoutGrid.RowDefinitions.Add(new(GridLength.Auto));
        _layoutGrid.RowDefinitions.Add(new(GridLength.Auto));
        _layoutGrid.RowDefinitions.Add(new(GridLength.Auto));
        _layoutGrid.RowDefinitions.Add(new(GridLength.Auto));
        
        _containerFrame.Content = _layoutGrid;
    }

    private void CreateHeader()
    {
        if (_confirmDialogConfig.HeaderImageSource == null)
        {
            _layoutGrid.RowDefinitions.RemoveAt(0);
            return;
        }

        View headerView = _confirmDialogConfig.HeaderImageSource switch
        {
            FontImageSource fontImageSource => new Label
            {
                FontFamily = fontImageSource.FontFamily,
                Text = fontImageSource.Glyph,
                TextColor = fontImageSource.Color,
                FontSize = fontImageSource.Size
            },
            FileImageSource fileImageSource => new Image() { Source = fileImageSource },
            UriImageSource uriImageSource => new Image() { Source = uriImageSource },
            _ => null
        };

        if (headerView == null) throw new InvalidOperationException("Invalid HeaderImageSource");

        headerView.HorizontalOptions = _confirmDialogConfig.HeaderImageHorizontalOptions;
        headerView.VerticalOptions = _confirmDialogConfig.HeaderImageVerticalOptions;

        _headerGrid = new Grid { headerView };
        _layoutGrid.Children.Add(_headerGrid);
        Grid.SetRow(_headerGrid, 0);
    }

    private void CreateTitle()
    {
        var titleLabel = new Label();

        if (_confirmDialogConfig.TitleFontSize != 0)
        {
            titleLabel.FontSize = _confirmDialogConfig.TitleFontSize;
        }

        if (!string.IsNullOrEmpty(_confirmDialogConfig.TitleFontFamily))
        {
            titleLabel.FontFamily = _confirmDialogConfig.TitleFontFamily;
        }

        titleLabel.Text = _confirmDialogConfig.Title;
        titleLabel.TextColor = _confirmDialogConfig.TitleFontColor;
        titleLabel.HorizontalTextAlignment = _confirmDialogConfig.TitleHorizontalTextAlignment;
        titleLabel.VerticalTextAlignment = _confirmDialogConfig.TitleVerticalTextAlignment;
        
        _titleGrid = new Grid();
        _titleGrid.Children.Add(titleLabel);
        
        _layoutGrid.Children.Add(_titleGrid);
        Grid.SetRow(_titleGrid, 1);
    }
    
    private void CreateDescription()
    {
        var descriptionLabel = new Label();

        if (_confirmDialogConfig.DescriptionFontSize != 0)
        {
            descriptionLabel.FontSize = _confirmDialogConfig.DescriptionFontSize;
        }

        if (!string.IsNullOrEmpty(_confirmDialogConfig.DescriptionFontFamily))
        {
            descriptionLabel.FontFamily = _confirmDialogConfig.DescriptionFontFamily;
        }

        descriptionLabel.Text = _confirmDialogConfig.Description;
        descriptionLabel.TextColor = _confirmDialogConfig.DescriptionFontColor;
        descriptionLabel.HorizontalTextAlignment = _confirmDialogConfig.DescriptionHorizontalTextAlignment;
        descriptionLabel.VerticalTextAlignment = _confirmDialogConfig.DescriptionVerticalTextAlignment;
        
        _descriptionGrid = new Grid();
        _descriptionGrid.Children.Add(descriptionLabel);
        
        _layoutGrid.Children.Add(_descriptionGrid);
        Grid.SetRow(_descriptionGrid, 2);
    }

    private void CreateActionButtons()
    {
        _positiveButton = new Button();
        _negativeButton = new Button();

        _positiveButton.Text = _confirmDialogConfig.PositiveButtonText;
        _positiveButton.BackgroundColor = _confirmDialogConfig.PositiveButtonColor;
        _positiveButton.TextColor = _confirmDialogConfig.PositiveButtonFontColor;
        _positiveButton.BorderColor = _confirmDialogConfig.PositiveButtonBorderColor;
        _positiveButton.BorderWidth = _confirmDialogConfig.PositiveButtonBorderWidth;

        if (_confirmDialogConfig.PositiveButtonFontSize != 0)
        {
            _positiveButton.FontSize = _confirmDialogConfig.PositiveButtonFontSize;
        }
        
        _negativeButton.Text = _confirmDialogConfig.NegativeButtonText;
        _negativeButton.BackgroundColor = _confirmDialogConfig.NegativeButtonColor;
        _negativeButton.TextColor = _confirmDialogConfig.NegativeButtonFontColor;
        _negativeButton.BorderColor = _confirmDialogConfig.NegativeButtonBorderColor;
        _negativeButton.BorderWidth = _confirmDialogConfig.NegativeButtonBorderWidth;

        if (_confirmDialogConfig.NegativeButtonFontSize != 0)
        {
            _negativeButton.FontSize = _confirmDialogConfig.NegativeButtonFontSize;
        }
        
        _actionGrid = new Grid();
        
        if (_confirmDialogConfig.ShowDontAskAgain)
        {
            _actionGrid.ColumnDefinitions.Add(new (GridLength.Auto));
        }
        
        _actionGrid.ColumnDefinitions.Add(new(GridLength.Star));
        _actionGrid.ColumnDefinitions.Add(new(GridLength.Star));
        
        _actionGrid.Children.Add(_positiveButton);
        Grid.SetColumn(_positiveButton, 0);
        
        _actionGrid.Children.Add(_positiveButton);
        Grid.SetColumn(_positiveButton, 1);
    }

    public override View CreateView()
    {
        return _containerFrame;
    }
}