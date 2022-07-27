using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Cards;
using Xunit;

namespace UFO.Tests.Controls;

public class UfoActionCardTest
{
    [Fact]
    public void Construction()
    {
        var ufoActionCard = new UfoActionCard
        {
            IsActionButtonVisible = true,
            ActionButtonBackground = Colors.Red,
            ActionButtonImageSource = new FileImageSource(),
            ActionButtonLayoutOptions = LayoutOptions.Fill,
            ActionButtonSize = 20,
            CornerRadius = 21,
            BorderWidth = 22,
            BorderColor = Colors.Yellow,
            TopView = new Image(),
            BottomView = new Label(),
            CloseButtonVisible = true,
            CloseButtonImageSource = new FileImageSource(),
            CloseButtonBackground = Colors.Beige,
            CloseButtonSize = 30.0
        };

        Assert.True(ufoActionCard.IsActionButtonVisible);
        Assert.Equal(new SolidColorBrush(Colors.Red), ufoActionCard.ActionButtonBackground);
        Assert.True(ufoActionCard.ActionButtonImageSource is FileImageSource);
        Assert.Equal(LayoutOptions.Fill, ufoActionCard.ActionButtonLayoutOptions);
        Assert.Equal(20, ufoActionCard.ActionButtonSize);
        Assert.Equal(21, ufoActionCard.CornerRadius);
        Assert.Equal(22, ufoActionCard.BorderWidth);
        Assert.Equal(Colors.Yellow, ufoActionCard.BorderColor);
        Assert.True(ufoActionCard.TopView is Image);
        Assert.True(ufoActionCard.BottomView is Label);
        Assert.True(ufoActionCard.CloseButtonVisible);
        Assert.True(ufoActionCard.CloseButtonImageSource is FileImageSource);
        Assert.Equal(Colors.Beige, ufoActionCard.CloseButtonBackground);
        Assert.Equal(30, ufoActionCard.CloseButtonSize);
    }
    
    [Fact]
    public void HasActionButtonDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.True(ufoActionCard.IsActionButtonVisible);
    }
    
    [Fact]
    public void IconBackgroundDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();

        var solidColorBrush = ufoActionCard.ActionButtonBackground as SolidColorBrush;
        Assert.Equal(new SolidColorBrush(Color.FromArgb("#7c54d4")).Color, solidColorBrush.Color);
    }

    [Fact]
    public void IconLayoutOptionsDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal(LayoutOptions.End, ufoActionCard.ActionButtonLayoutOptions);
    }
    
    [Fact]
    public void IconSizeDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal(60.0, ufoActionCard.ActionButtonSize);
    }
    
    [Fact]
    public void CornerRadiusDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal(15f, ufoActionCard.CornerRadius);
    }
    
    [Fact]
    public void BorderColorDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal(Colors.LightGray, ufoActionCard.BorderColor);
    }
    
    [Fact]
    public void BorderWidthDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal( 2.0, ufoActionCard.BorderWidth);
    }
    
    [Fact]
    public void CloseSizeDefaultValue()
    {
        var ufoActionCard = new UfoActionCard();
        Assert.Equal(20.0, ufoActionCard.CloseButtonSize);
    }

	[Fact]
	public void CloseVisibleDefaultValue()
	{
		var ufoActionCard = new UfoActionCard();
		Assert.False(ufoActionCard.CloseButtonVisible);
	}
}