using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Cards;
using Xunit;

namespace UFO.Tests.Controls;

public class UfoParallaxCardTest 
{
    [Fact]
    public void Construction()
    {
        var ufoParallaxCard = new UfoParallaxCard
        {
            BackgroundView = new Image(),
            ForegroundView = new Label(),
            CornerRadius = 10,
            BorderColor = Colors.Aqua,
            CloseButtonVisible = true,
            CloseButtonImageSource = new FontImageSource(),
            CloseButtonSize = 20,
            CloseButtonBackground = Colors.Red,
        };

        Assert.True(ufoParallaxCard.BackgroundView is Image);
        Assert.True(ufoParallaxCard.ForegroundView is Label);
        Assert.Equal(10, ufoParallaxCard.CornerRadius);
        Assert.Equal(Colors.Aqua, ufoParallaxCard.BorderColor);
        Assert.Equal(Colors.Red, ufoParallaxCard.CloseButtonBackground);
        Assert.Equal(20, ufoParallaxCard.CloseButtonSize);
        Assert.True(ufoParallaxCard.CloseButtonImageSource is FontImageSource);
	}

	[Fact]
    public void CornerRadiusDefaultValue()
    {
        var ufoParallaxCard = new UfoParallaxCard();
        Assert.Equal(15f, ufoParallaxCard.CornerRadius);
    }
    
    [Fact]
    public void BorderColorDefaultValue()
    {
        var ufoParallaxCard = new UfoParallaxCard();
        Assert.Equal(Colors.LightGray, ufoParallaxCard.BorderColor);
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