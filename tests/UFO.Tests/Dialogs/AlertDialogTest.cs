using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Dialogs;
using UFO.UI.Dialogs.Configs;
using Xunit;

namespace UFO.Tests.Dialogs;

[Collection("Sequential")]
public class AlertDialogTest : DialogTest
{
    [Fact]
    public void ContainerConstruction()
    {
        var config = new AlertDialogConfig
        {
            BackgroundColor = Colors.Brown,
        };
        
        var alertDialog = new AlertDialog(config);

        var dialogContainer = GetDialogControl<Frame>(alertDialog, "DialogContainer"); 
        Assert.Equal(15, dialogContainer.CornerRadius);
        Assert.Equal(Colors.Brown, dialogContainer.BackgroundColor);
    }

    [Fact]
    public void HeaderConstruction()
    {
        var config = new AlertDialogConfig
        {
            IconHeight = 20,
            IconWidth = 30,
            IconHorizontalOptions = LayoutOptions.End,
            IconVerticalOptions = LayoutOptions.Fill,
            IconSource = new FileImageSource(){File = "test.png"},
        }; 
        
        var alertDialog = new AlertDialog(config);
        
        var headerImage = GetDialogControl<Image>(alertDialog, "HeaderImage");
        Assert.True(headerImage.Source is FileImageSource);
        Assert.Equal(LayoutOptions.End, headerImage.HorizontalOptions);
        Assert.Equal(LayoutOptions.Fill, headerImage.VerticalOptions);
        Assert.Equal(20, headerImage.HeightRequest);
        Assert.Equal(30, headerImage.WidthRequest);
    }

    [Fact]
    public void TitleConstruction()
    {
        var config = new AlertDialogConfig
        {
            Title = nameof(AlertDialog),
            TitleFontColor = Colors.Aqua,
            TitleFontSize = 22,
            TitleFontFamily = nameof(AlertDialog),
        };
        
        var alertDialog = new AlertDialog(config);
        
        var titleLabel = GetDialogControl<Label>(alertDialog, "TitleLabel");
        Assert.Equal(nameof(AlertDialog), titleLabel.Text);
        Assert.Equal(Colors.Aqua, titleLabel.TextColor);
        Assert.Equal(22, titleLabel.FontSize);
        Assert.Equal(nameof(AlertDialog), titleLabel.FontFamily);
    }
    
    [Fact]
    public void DescriptionConstruction()
    {
        var config = new AlertDialogConfig
        {
            Description = nameof(AlertDialog),
            DescriptionFontColor = Colors.Black,
            DescriptionFontFamily = nameof(AlertDialog),
        };
        
        var alertDialog = new AlertDialog(config);
        
        var descriptionLabel = GetDialogControl<Label>(alertDialog, "DescriptionLabel");
        Assert.Equal(nameof(AlertDialog), descriptionLabel.Text);
        Assert.Equal(Colors.Black, descriptionLabel.TextColor);
        Assert.Equal(nameof(AlertDialog), descriptionLabel.FontFamily);
    }

    [Fact]
    public void PositiveButtonConstruction()
    {
        var config = new AlertDialogConfig
        {
            ConfirmButtonConfig = new DialogButtonConfig
            {
                Background = new SolidColorBrush(Colors.Red),
                BorderColor = Colors.Yellow,
                BorderWidth = 2.0,
                FontFamily = nameof(AlertDialog),
                FontSize = 20,
                Text = nameof(AlertDialog),
                TextColor = Colors.Beige
            },
        };
        
        var alertDialog = new AlertDialog(config);
        
        var positiveButton = GetDialogControl<Button>(alertDialog, "PositiveButton");
        Assert.Equal(new SolidColorBrush(Colors.Red), positiveButton.Background);
        Assert.Equal(nameof(AlertDialog), positiveButton.Text);
        Assert.Equal(nameof(AlertDialog), positiveButton.FontFamily);
        Assert.Equal(Colors.Yellow, positiveButton.BorderColor);
        Assert.Equal(2.0, positiveButton.BorderWidth);
        Assert.Equal(Colors.Beige, positiveButton.TextColor);
    }
}