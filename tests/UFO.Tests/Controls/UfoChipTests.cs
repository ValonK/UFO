using System.Diagnostics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using UFO.UI.Controls;
using Xunit;

namespace UFO.Tests.Controls;

public class UfoChipTests
{
	[Fact]
	public void Construction()
	{
		var ufoChip = new UfoChip();
		ufoChip.ChipBackground = Colors.Brown;
		ufoChip.Text = nameof(ufoChip.Text);
		ufoChip.FontFamily = nameof(ufoChip.FontFamily);
		ufoChip.ChipBorderColor = Colors.Aqua;
		ufoChip.IconImageSource = new FileImageSource();
		ufoChip.CloseIconImageSource = new FileImageSource();
		
		Assert.Equal(Colors.Brown, ufoChip.ChipBackground);
		Assert.Equal(nameof(ufoChip.Text), ufoChip.Text);
		Assert.Equal(nameof(ufoChip.FontFamily), ufoChip.FontFamily);
		Assert.Equal(Colors.Aqua, ufoChip.ChipBorderColor);
		Assert.True(ufoChip.IconImageSource is FileImageSource);
		Assert.True(ufoChip.CloseIconImageSource is FileImageSource);
	}

	[Fact]
	public void BorderColorDefaultValue()
	{
		var ufoChip = new UfoChip();
		Assert.Equal(Colors.Transparent, ufoChip.ChipBorderColor);
	}
	
	[Fact]
	public void TextDefaultValue()
	{
		var ufoChip = new UfoChip();
		Assert.Equal(nameof(UfoChip), ufoChip.Text);
	}
	
	[Fact]
	public void TextColorDefaultValue()
	{
		var ufoChip = new UfoChip();
		Assert.Equal(Colors.Black, ufoChip.TextColor);
	}
}
