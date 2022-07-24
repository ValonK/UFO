using Microsoft.Maui.Graphics;
using UFO.UI.Controls.Selection;
using Xunit;

namespace UFO.Tests.Controls;

public class UfoCheckBoxTest
{
    [Fact]
    public void Construction()
    {
        var ufoCheckBox = new UfoCheckBox();
        ufoCheckBox.Color = Colors.Red;
        ufoCheckBox.TextColor = Colors.Yellow;
        ufoCheckBox.FontFamily = nameof(ufoCheckBox.FontFamily);
        ufoCheckBox.IsChecked = true;
        ufoCheckBox.Text = nameof(ufoCheckBox.Text);
        
        Assert.Equal(Colors.Red, ufoCheckBox.Color);
        Assert.Equal(Colors.Yellow, ufoCheckBox.TextColor);
        Assert.Equal(nameof(ufoCheckBox.FontFamily), ufoCheckBox.FontFamily);
        Assert.True(ufoCheckBox.IsChecked);
        Assert.Equal(nameof(ufoCheckBox.Text), ufoCheckBox.Text);
    }

    [Fact]
    public void TextColorDefaultValue()
    {
        var ufoCheckBox = new UfoCheckBox();
        Assert.Equal(Colors.Black, ufoCheckBox.TextColor);
    }
    
    [Fact]
    public void ColorDefaultValue()
    {
        var ufoCheckBox = new UfoCheckBox();
        Assert.Equal(Color.FromArgb("#7c54d4"), ufoCheckBox.Color);
    }
}