using System.Windows.Input;
using UFO.UI.Builders;

namespace UFO.UI.Controls.Cards;

public class UfoActionCard : UfoCard
{	
	public static readonly BindableProperty HasActionButtonProperty = BindableProperty.Create(nameof(HasActionButton), typeof(bool), typeof(UfoActionCard), defaultValue: true);
	public static readonly BindableProperty IconCommandProperty = BindableProperty.Create(nameof(IconCommand), typeof(ICommand), typeof(UfoActionCard));
	public static readonly BindableProperty IconBackgroundProperty = BindableProperty.Create(nameof(IconBackground), typeof(Brush), typeof(UfoActionCard));
	public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoActionCard));
	public static readonly BindableProperty IconLayoutOptionsProperty = BindableProperty.Create(nameof(IconLayoutOptions), typeof(LayoutOptions), typeof(UfoActionCard));
	public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(UfoActionCard));

	public UfoActionCard()
	{
		Content = new ActionCardBuilder(this).Build();
	}

	public bool HasActionButton
	{
		get => (bool)GetValue(HasActionButtonProperty);
		set => SetValue(HasActionButtonProperty, value);
	}

	public ICommand IconCommand
	{
		get => (ICommand)GetValue(IconCommandProperty);
		set => SetValue(IconCommandProperty, value);
	}

	public Brush IconBackground
	{
		get => (Brush)GetValue(IconBackgroundProperty);
		set => SetValue(IconBackgroundProperty, value);
	}

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public LayoutOptions IconLayoutOptions
	{
		get => (LayoutOptions)GetValue(IconLayoutOptionsProperty);
		set => SetValue(IconLayoutOptionsProperty, value);
	}

	public double IconSize
	{
		get => (double)GetValue(IconSizeProperty);
		set => SetValue(IconSizeProperty, value);
	}
}