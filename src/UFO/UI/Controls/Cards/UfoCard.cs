using System.Windows.Input;
using UFO.Utilities;

namespace UFO.UI.Controls.Cards;

public abstract class UfoCard : ContentView
{
	public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(UfoCard), defaultValue: UfoSizes.DefaultCornerRadios);
	public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(UfoCard), defaultValue: Colors.LightGray);
	public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(UfoCard), defaultValue: 2.0);
	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(UfoCard));
	public static readonly BindableProperty CloseButtonVisibleProperty = BindableProperty.Create(nameof(CloseButtonVisible), typeof(bool), typeof(UfoCard));
	public static readonly BindableProperty CloseButtonImageSourceProperty = BindableProperty.Create(nameof(CloseButtonImageSource), typeof(ImageSource), typeof(UfoCard));
	public static readonly BindableProperty CloseCloseButtonCommandProperty = BindableProperty.Create(nameof(CloseButtonCommand), typeof(ICommand), typeof(UfoCard));
	public static readonly BindableProperty CloseButtonBackgroundProperty = BindableProperty.Create(nameof(CloseButtonBackground), typeof(Brush), typeof(UfoCard));
	public static readonly BindableProperty CloseButtonSizeProperty = BindableProperty.Create(nameof(CloseButtonSize), typeof(double), typeof(UfoCard), defaultValue: 20.0);

	public float CornerRadius
	{
		get => (float)GetValue(CornerRadiusProperty);
		set => SetValue(CornerRadiusProperty, value);
	}

	public double BorderWidth
	{
		get => (double)GetValue(BorderWidthProperty);
		set => SetValue(BorderWidthProperty, value);
	}

	public Color BorderColor
	{
		get => (Color)GetValue(BorderColorProperty);
		set => SetValue(BorderColorProperty, value);
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public ImageSource CloseButtonImageSource
	{
		get => (ImageSource)GetValue(CloseButtonImageSourceProperty);
		set => SetValue(CloseButtonImageSourceProperty, value);
	}

	public Brush CloseButtonBackground
	{
		get => (Brush)GetValue(CloseButtonBackgroundProperty);
		set => SetValue(CloseButtonBackgroundProperty, value);
	}

	public ICommand CloseButtonCommand
	{
		get => (ICommand)GetValue(CloseCloseButtonCommandProperty);
		set => SetValue(CloseCloseButtonCommandProperty, value);
	}

	public double CloseButtonSize
	{
		get => (double)GetValue(CloseButtonSizeProperty);
		set => SetValue(CloseButtonSizeProperty, value);
	}

	public bool CloseButtonVisible
	{
		get => (bool)GetValue(CloseButtonVisibleProperty);
		set => SetValue(CloseButtonVisibleProperty, value);
	}
}
