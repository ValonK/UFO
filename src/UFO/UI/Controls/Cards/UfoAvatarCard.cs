using UFO.UI.Builders;

namespace UFO.UI.Controls.Cards;

public class UfoAvatarCard : UfoCard
{
	public static readonly BindableProperty AvatarBackgroundColorProperty = BindableProperty.Create(nameof(AvatarBackgroundColor), typeof(Color), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarBorderColorProperty = BindableProperty.Create(nameof(AvatarBorderColor), typeof(Color), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarBorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarSizeProperty = BindableProperty.Create(nameof(AvatarSize), typeof(double), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarTextProperty = BindableProperty.Create(nameof(AvatarText), typeof(string), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarTextColorProperty = BindableProperty.Create(nameof(AvatarTextColor), typeof(Color), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarImageSourceProperty = BindableProperty.Create(nameof(AvatarImageSource), typeof(ImageSource), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarPaddingProperty = BindableProperty.Create(nameof(AvatarPadding), typeof(Thickness), typeof(UfoAvatarCard));	

	public UfoAvatarCard()
	{
		Content = new AvatarCardBuilder(this).Build();
	}

	public Color AvatarBackgroundColor
	{
		get => (Color)GetValue(AvatarBackgroundColorProperty);
		set => SetValue(AvatarBackgroundColorProperty, value);
	}

	public Color AvatarBorderColor
	{
		get => (Color)GetValue(AvatarBorderColorProperty);
		set => SetValue(AvatarBorderColorProperty, value);
	}

	public double AvatarBorderWidth
	{
		get => (double)GetValue(AvatarBorderWidthProperty);
		set => SetValue(AvatarBorderWidthProperty, value);
	}

	public double AvatarSize
	{
		get => (double)GetValue(AvatarSizeProperty);
		set => SetValue(AvatarSizeProperty, value);
	}

	public string AvatarText
	{
		get => (string)GetValue(AvatarTextProperty);
		set => SetValue(AvatarTextProperty, value);
	}

	public ImageSource AvatarImageSource
	{
		get => (ImageSource)GetValue(AvatarImageSourceProperty);
		set => SetValue(AvatarImageSourceProperty, value);
	}

	public Thickness AvatarPadding
	{
		get => (Thickness)GetValue(AvatarPaddingProperty);
		set => SetValue(AvatarPaddingProperty, value);
	}

	public Color AvatarTextColor
	{
		get => (Color)GetValue(AvatarTextColorProperty);
		set => SetValue(AvatarTextColorProperty, value);
	}
}
