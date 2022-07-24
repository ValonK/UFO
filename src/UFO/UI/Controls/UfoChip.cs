using System.Windows.Input;
using UFO.UI.Builders;

namespace UFO.UI.Controls;

public class UfoChip : ContentView
{
	public static readonly BindableProperty ChipBorderColorProperty = BindableProperty.Create(nameof(ChipBorderColor), typeof(Color), typeof(UfoChip), defaultValue: Colors.Transparent);
	public static readonly BindableProperty ChipBackgroundProperty = BindableProperty.Create(nameof(ChipBackground), typeof(Brush), typeof(UfoChip));
	public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoChip));
	public static readonly BindableProperty CloseIconImageSourceProperty = BindableProperty.Create(nameof(CloseIconImageSource), typeof(ImageSource), typeof(UfoChip));
	public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(UfoChip));
	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(UfoChip));
	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(UfoChip));
	public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(UfoChip));
	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UfoChip));

	public UfoChip()
	{
		Content = new ChipBuilder(this).Build();
	}

	public Color ChipBorderColor
	{
		get => (Color)GetValue(ChipBorderColorProperty);
		set => SetValue(ChipBorderColorProperty, value);
	}

	public Brush ChipBackground
	{
		get => (Brush)GetValue(ChipBackgroundProperty);
		set => SetValue(ChipBackgroundProperty, value);
	}

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public ImageSource CloseIconImageSource
	{
		get => (ImageSource)GetValue(CloseIconImageSourceProperty);
		set => SetValue(CloseIconImageSourceProperty, value);
	}

	public ICommand CloseCommand
	{
		get => (ICommand)GetValue(CloseCommandProperty);
		set => SetValue(CloseCommandProperty, value);
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
}