using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Cards;
using Xunit;

namespace UFO.Tests.Controls;

public class UfoAvatarCardTest
{
    [Fact]
    public void Construction()
    {
        var ufoAvatarCard = new UfoAvatarCard
        {
            AvatarBackgroundColor = Colors.Red,
            AvatarBorderColor = Colors.Yellow,
            AvatarBorderWidth = 1.0,
            AvatarSize = 2.0,
            AvatarText = nameof(UfoAvatarCard),
            AvatarImageSource = new FileImageSource(),
            AvatarPadding = new Thickness(1,1,1,1),
            AvatarTextColor = Colors.Beige,
            CornerRadius = 21,
            BorderWidth = 22,
            BorderColor = Colors.Yellow,
            TopView = new Image(),
            BottomView = new Label(),
            CloseImageSource = new FileImageSource(),
            CloseBackground = Colors.Beige,
            CloseSize = 30.0
        };

        Assert.Equal(Colors.Red, ufoAvatarCard.AvatarBackgroundColor);
        Assert.Equal(Colors.Yellow, ufoAvatarCard.AvatarBorderColor);
        Assert.Equal(1.0, ufoAvatarCard.AvatarBorderWidth);
        Assert.Equal(2.0, ufoAvatarCard.AvatarSize);
        Assert.Equal(nameof(UfoAvatarCard), ufoAvatarCard.AvatarText);
        Assert.True(ufoAvatarCard.AvatarImageSource is FileImageSource);
        Assert.Equal(new Thickness(1,1,1,1), ufoAvatarCard.AvatarPadding);
        Assert.Equal(Colors.Beige, ufoAvatarCard.AvatarTextColor);
        Assert.Equal(21, ufoAvatarCard.CornerRadius);
        Assert.Equal(22, ufoAvatarCard.BorderWidth);
        Assert.Equal(Colors.Yellow, ufoAvatarCard.BorderColor);
        Assert.Equal(21, ufoAvatarCard.CornerRadius);
        Assert.Equal(22, ufoAvatarCard.BorderWidth);
        Assert.True(ufoAvatarCard.TopView is Image);
        Assert.True(ufoAvatarCard.BottomView is Label);
        Assert.True(ufoAvatarCard.CloseImageSource is FileImageSource);
        Assert.Equal(Colors.Beige, ufoAvatarCard.CloseBackground);
        Assert.Equal(30, ufoAvatarCard.CloseSize);
    }
    
    [Fact]
    public void AvatarBackgroundColorDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(Colors.White, ufoAvatarCard.AvatarBackgroundColor);
    }
        
    [Fact]
    public void AvatarBorderColorDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(Colors.LightGray, ufoAvatarCard.AvatarBorderColor);
    }
    
    [Fact]
    public void AvatarBorderWidthDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(2.0, ufoAvatarCard.AvatarBorderWidth);
    }
    
    [Fact]
    public void AvatarSizeDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(60.0, ufoAvatarCard.AvatarSize);
    }
    
    [Fact]
    public void AvatarTextDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal("UFO", ufoAvatarCard.AvatarText);
    }
    
    [Fact]
    public void AvatarTextColorDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(Colors.Black, ufoAvatarCard.AvatarTextColor);
    }

    [Fact]
    public void CornerRadiusDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(15f, ufoAvatarCard.CornerRadius);
    }
    
    [Fact]
    public void BorderColorDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(Colors.LightGray, ufoAvatarCard.BorderColor);
    }
    
    [Fact]
    public void BorderWidthDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal( 2.0, ufoAvatarCard.BorderWidth);
    }
    
    [Fact]
    public void CloseSizeDefaultValue()
    {
        var ufoAvatarCard = new UfoAvatarCard();
        Assert.Equal(20.0, ufoAvatarCard.CloseSize);
    }
}