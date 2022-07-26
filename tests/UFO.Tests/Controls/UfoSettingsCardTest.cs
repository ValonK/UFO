using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Cards;
using Xunit;

namespace UFO.Tests.Controls;

[Collection("Sequential")]
public class UfoSettingsCardTest
{
    [Fact]
    public void Construction()
    {
        var ufoSettingsCard = new UfoSettingsCard()
        {
            IconImageSource = new FileImageSource(),
            IconVerticalOptions = LayoutOptions.Center,
            Title = "Title",
            TitleFontAttributes = FontAttributes.Bold,
            TitleTextColor = Colors.Yellow,
            TitleFontFamily = "TitleFontFamily",
            TitleFontSize = 21,
            Description = "Description",
            DescriptionFontAttributes = FontAttributes.Bold,
            DescriptionFontFamily = "DescriptionFontFamily",
            DescriptionTextColor = Colors.RosyBrown,
            DescriptionFontSize = 17,
			SettingsView = new Label(),
        };
        
        Assert.True(ufoSettingsCard.IconImageSource is FileImageSource);
        Assert.Equal(LayoutOptions.Center, ufoSettingsCard.IconVerticalOptions);
        Assert.Equal("Title", ufoSettingsCard.Title);
		Assert.Equal(21, ufoSettingsCard.TitleFontSize);
		Assert.Equal(FontAttributes.Bold, ufoSettingsCard.TitleFontAttributes);
        Assert.Equal(Colors.Yellow, ufoSettingsCard.TitleTextColor);
        Assert.Equal("TitleFontFamily", ufoSettingsCard.TitleFontFamily);
        Assert.Equal("Description", ufoSettingsCard.Description);
        Assert.Equal(FontAttributes.Bold, ufoSettingsCard.DescriptionFontAttributes);
        Assert.Equal(Colors.RosyBrown, ufoSettingsCard.DescriptionTextColor);
        Assert.Equal(17, ufoSettingsCard.DescriptionFontSize);
        Assert.Equal("DescriptionFontFamily", ufoSettingsCard.DescriptionFontFamily);
        Assert.True(ufoSettingsCard.SettingsView is Label);
    }
    
    [Fact]
    public void TitleTextColorDefaultValue()
    {
        var ufoSettingsCard = new UfoSettingsCard();
        Assert.Equal(Colors.Black, ufoSettingsCard.TitleTextColor);
    }

	[Fact]
	public void TitleFontSizeDefaultValue()
	{
		var ufoSettingsCard = new UfoSettingsCard();
		Assert.Equal(20, ufoSettingsCard.TitleFontSize);
	}

	[Fact]
    public void DescriptionTextColorDefaultValue()
    {
        var ufoSettingsCard = new UfoSettingsCard();
        Assert.Equal(Colors.Black, ufoSettingsCard.DescriptionTextColor);
    }

	[Fact]
	public void DescriptionFontSizeDefaultValue()
	{
		var ufoSettingsCard = new UfoSettingsCard();
		Assert.Equal(17, ufoSettingsCard.DescriptionFontSize);
	}

	[Fact]
	public void IconVerticalOptionsDefaultValue()
	{
		var ufoSettingsCard = new UfoSettingsCard();
		Assert.Equal(LayoutOptions.Center, ufoSettingsCard.IconVerticalOptions);
	}
}