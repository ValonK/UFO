using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Selection;
using UFO.UI.Dialogs;
using UFO.UI.Dialogs.Configs;
using Xunit;

namespace UFO.Tests.Dialogs;

[Collection("Sequential")]
public class ConfirmDialogTests : DialogTest
{
    [Fact]
    public void ContainerConstruction()
    {
        var config = new ConfirmDialogConfig()
        {
            BackgroundColor = Colors.Brown
        };
        
        var confirmDialog = new ConfirmDialog(config);

        var dialogContainer = GetDialogControl<Frame>(confirmDialog, "DialogContainer"); 
        Assert.Equal(15, dialogContainer.CornerRadius);
        Assert.Equal(Colors.Brown, dialogContainer.BackgroundColor);
    }
    
    [Fact]
    public void HeaderConstruction()
    {
        var config = new ConfirmDialogConfig
        {
            IconHeight = 20,
            IconWidth = 30,
            IconHorizontalOptions = LayoutOptions.End,
            IconVerticalOptions = LayoutOptions.Fill,
            IconSource = new FileImageSource(){File = "test.png"},
        }; 
        
        var confirmDialog = new ConfirmDialog(config);
        
        var headerImage = GetDialogControl<Image>(confirmDialog, "HeaderImage");
        Assert.True(headerImage.Source is FileImageSource);
        Assert.Equal(LayoutOptions.End, headerImage.HorizontalOptions);
        Assert.Equal(LayoutOptions.Fill, headerImage.VerticalOptions);
        Assert.Equal(20, headerImage.HeightRequest);
        Assert.Equal(30, headerImage.WidthRequest);
    }
    
    [Fact]
    public void TitleConstruction()
    {
        var config = new ConfirmDialogConfig
        {
            Title = nameof(AlertDialog),
            TitleFontColor = Colors.Aqua,
            TitleFontSize = 22,
            TitleFontFamily = nameof(AlertDialog),
        };
        
        var confirmDialog = new ConfirmDialog(config);
        
        var titleLabel = GetDialogControl<Label>(confirmDialog, "TitleLabel");
        Assert.Equal(nameof(AlertDialog), titleLabel.Text);
        Assert.Equal(Colors.Aqua, titleLabel.TextColor);
        Assert.Equal(22, titleLabel.FontSize);
        Assert.Equal(nameof(AlertDialog), titleLabel.FontFamily);
    }
    
    [Fact]
    public void DescriptionConstruction()
    {
        var config = new ConfirmDialogConfig
        {
            Description = nameof(AlertDialog),
            DescriptionFontColor = Colors.Black,
            DescriptionFontFamily = nameof(AlertDialog),
        };
        
        var confirmDialog = new ConfirmDialog(config);
        
        var descriptionLabel = GetDialogControl<Label>(confirmDialog, "DescriptionLabel");
        Assert.Equal(nameof(AlertDialog), descriptionLabel.Text);
        Assert.Equal(Colors.Black, descriptionLabel.TextColor);
        Assert.Equal(nameof(AlertDialog), descriptionLabel.FontFamily);
    }
    
    [Fact]
    public void DeclineButtonConstruction()
    {
        var config = new ConfirmDialogConfig
        {
            DeclineButtonConfig = new DialogButtonConfig()
            {
                Background = new SolidColorBrush(Colors.Red),
                BorderColor = Colors.Yellow,
                BorderWidth = 2.0,
                FontFamily = nameof(AlertDialog),
                FontSize = 20,
                Text = nameof(AlertDialog),
                TextColor = Colors.Beige
            }
        };
        
        var alertDialog = new ConfirmDialog(config);
        
        var positiveButton = GetDialogControl<Button>(alertDialog, "DeclineButton");
        Assert.Equal(new SolidColorBrush(Colors.Red), positiveButton.Background);
        Assert.Equal(nameof(AlertDialog), positiveButton.Text);
        Assert.Equal(nameof(AlertDialog), positiveButton.FontFamily);
        Assert.Equal(Colors.Yellow, positiveButton.BorderColor);
        Assert.Equal(2.0, positiveButton.BorderWidth);
        Assert.Equal(Colors.Beige, positiveButton.TextColor);
    }
    
    [Fact]
    public void ConfirmButtonConstruction()
    {
        var config = new ConfirmDialogConfig
        {
            ConfirmButtonConfig = new DialogButtonConfig()
            {
                Background = new SolidColorBrush(Colors.Red),
                BorderColor = Colors.Yellow,
                BorderWidth = 2.0,
                FontFamily = nameof(AlertDialog),
                FontSize = 20,
                Text = nameof(AlertDialog),
                TextColor = Colors.Beige
            }
        };
        
        var alertDialog = new ConfirmDialog(config);
        
        var positiveButton = GetDialogControl<Button>(alertDialog, "ConfirmButton");
        Assert.Equal(new SolidColorBrush(Colors.Red), positiveButton.Background);
        Assert.Equal(nameof(AlertDialog), positiveButton.Text);
        Assert.Equal(nameof(AlertDialog), positiveButton.FontFamily);
        Assert.Equal(Colors.Yellow, positiveButton.BorderColor);
        Assert.Equal(2.0, positiveButton.BorderWidth);
        Assert.Equal(Colors.Beige, positiveButton.TextColor);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CheckBoxConstruction(bool dontAskAgainEnabled)
    {
        var config = new ConfirmDialogConfig
        {
            ShowDontAskAgain = dontAskAgainEnabled,
            DontAskAgainFontColor = Colors.RosyBrown,
            DontAskAgainText = nameof(ConfirmDialog)
        };

        var confirmDialog = new ConfirmDialog(config);

        var checkBox = GetDialogControl<UfoCheckBox>(confirmDialog, "DontAskAgainCheckBox");
        Assert.Equal(dontAskAgainEnabled, checkBox.IsVisible);

        if (dontAskAgainEnabled)
        {
            Assert.Equal(Colors.RosyBrown, checkBox.TextColor);
            Assert.Equal(nameof(ConfirmDialog), checkBox.Text);
        }
    }
}