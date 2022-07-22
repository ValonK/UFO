using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UFO.UI.Controls.Cards;

public partial class UfoActionCard : Card
{
	public UfoActionCard()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty HasActionButtonProperty =
		BindableProperty.Create(nameof(HasActionButton), typeof(bool), typeof(UfoActionCard), defaultValue: true);

	public bool HasActionButton
	{
		get => (bool)GetValue(HasActionButtonProperty);
		set => SetValue(HasActionButtonProperty, value);
	}

	public static readonly BindableProperty TopViewProperty =
		BindableProperty.Create(nameof(TopView), typeof(View), typeof(UfoActionCard));

	public View TopView
	{
		get => (View)GetValue(TopViewProperty);
		set => SetValue(TopViewProperty, value);
	}

	public static readonly BindableProperty BottomViewProperty =
		BindableProperty.Create(nameof(BottomView), typeof(View), typeof(UfoActionCard));

	public View BottomView
	{
		get => (View)GetValue(BottomViewProperty);
		set => SetValue(BottomViewProperty, value);
	}

	public static readonly BindableProperty IconCommandProperty =
		BindableProperty.Create(nameof(IconCommand), typeof(ICommand), typeof(UfoActionCard));

	public ICommand IconCommand
	{
		get => (ICommand)GetValue(IconCommandProperty);
		set => SetValue(IconCommandProperty, value);
	}

	public static readonly BindableProperty IconBackgroundProperty =
		BindableProperty.Create(nameof(IconBackground), typeof(Brush), typeof(UfoActionCard));

	public Brush IconBackground
	{
		get => (Brush)GetValue(IconBackgroundProperty);
		set => SetValue(IconBackgroundProperty, value);
	}

	public static readonly BindableProperty IconImageSourceProperty =
		BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoActionCard));

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public static readonly BindableProperty IconLayoutOptionsProperty =
	BindableProperty.Create(nameof(IconLayoutOptions), typeof(LayoutOptions), typeof(UfoActionCard));

	public LayoutOptions IconLayoutOptions
	{
		get => (LayoutOptions)GetValue(IconLayoutOptionsProperty);
		set => SetValue(IconLayoutOptionsProperty, value);
	}

	public static readonly BindableProperty IconSizeProperty =
		BindableProperty.Create(nameof(IconSize), typeof(double), typeof(UfoActionCard));

	public double IconSize
	{
		get => (double)GetValue(IconSizeProperty);
		set => SetValue(IconSizeProperty, value);
	}
	
	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		if (propertyName == nameof(IconSize))
		{
			ActionButton.HeightRequest = IconSize;
			ActionButton.WidthRequest= IconSize;

			var cornerRadius = (int)(IconSize / 2);
			ActionButton.CornerRadius = cornerRadius;
			ActionButton.Margin = new Thickness(0, 0, 10, -cornerRadius);
		}
	}
}