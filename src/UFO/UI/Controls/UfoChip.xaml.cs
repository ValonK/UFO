namespace UFO.UI.Controls;

public partial class UfoChip : ContentView
{
	public UfoChip()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty ChipBorderColorProperty =
		BindableProperty.Create(nameof(ChipBorderColor), typeof(Color), typeof(UfoChip), defaultValue: Colors.Transparent);

	public Color ChipBorderColor
	{
		get => (Color)GetValue(ChipBorderColorProperty);
		set => SetValue(ChipBorderColorProperty, value);
	}

	public static readonly BindableProperty ChipBackgroundProperty =
		BindableProperty.Create(nameof(ChipBackground), typeof(Brush), typeof(UfoChip));

	public Brush ChipBackground
	{
		get => (Brush)GetValue(ChipBackgroundProperty);
		set => SetValue(ChipBackgroundProperty, value);
	}

	public static readonly BindableProperty IconImageSourceProperty =
		BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoChip));

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public static readonly BindableProperty CloseIconImageSourceProperty =
		BindableProperty.Create(nameof(CloseIconImageSource), typeof(ImageSource), typeof(UfoChip));

	public ImageSource CloseIconImageSource
	{
		get => (ImageSource)GetValue(CloseIconImageSourceProperty);
		set => SetValue(CloseIconImageSourceProperty, value);
	}

	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text), typeof(string), typeof(UfoChip));

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty FontFamilyProperty =
		BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(UfoChip));

	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}

	public static readonly BindableProperty TextColorProperty =
		BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UfoChip));

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
}