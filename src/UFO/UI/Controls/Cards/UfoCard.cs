using System.Windows.Input;
using UFO.Utilities;

namespace UFO.UI.Controls.Cards;

public abstract class UfoCard : ContentView
{
	public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(UfoCard), defaultValue: UfoSizes.DefaultCornerRadios);
	public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(UfoCard), defaultValue: Colors.LightGray);
	public static readonly BindableProperty TopViewProperty = BindableProperty.Create(nameof(TopView), typeof(View), typeof(UfoCard));
	public static readonly BindableProperty BottomViewProperty = BindableProperty.Create(nameof(BottomView), typeof(View), typeof(UfoCard));
	public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(UfoCard));
	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(UfoCard));
	public static readonly BindableProperty CloseImageSourceProperty = BindableProperty.Create(nameof(CloseImageSource), typeof(ImageSource), typeof(UfoAvatarCard));
	public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(UfoAvatarCard));
	public static readonly BindableProperty CloseBackgroundProperty = BindableProperty.Create(nameof(CloseBackground), typeof(Brush), typeof(UfoAvatarCard));
	public static readonly BindableProperty CloseSizeProperty = BindableProperty.Create(nameof(CloseSize), typeof(double), typeof(UfoAvatarCard), defaultValue: 20);
	
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

	public View TopView
	{
		get => (View)GetValue(TopViewProperty);
		set => SetValue(TopViewProperty, value);
	}

	public View BottomView
	{
		get => (View)GetValue(BottomViewProperty);
		set => SetValue(BottomViewProperty, value);
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public ImageSource CloseImageSource
	{
		get => (ImageSource)GetValue(CloseImageSourceProperty);
		set => SetValue(CloseImageSourceProperty, value);
	}

	public Brush CloseBackground
	{
		get => (Brush)GetValue(CloseBackgroundProperty);
		set => SetValue(CloseBackgroundProperty, value);
	}

	public ICommand CloseCommand
	{
		get => (ICommand)GetValue(CloseCommandProperty);
		set => SetValue(CloseCommandProperty, value);
	}

	public double CloseSize
	{
		get => (double)GetValue(CloseSizeProperty);
		set => SetValue(CloseSizeProperty, value);
	}
}
