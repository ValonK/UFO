using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UFO.UI.Controls.Cards;

public partial class UfoActionCard : Card
{
	public UfoActionCard()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty BorderColorProperty =
		BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(UfoActionCard), defaultValue: Colors.Transparent);

	public Color BorderColor
	{
		get => (Color)GetValue(BorderColorProperty);
		set => SetValue(BorderColorProperty, value);
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

	public static readonly BindableProperty ActionIconCommandProperty =
		BindableProperty.Create(nameof(ActionIconCommand), typeof(ICommand), typeof(UfoActionCard));

	public ICommand ActionIconCommand
	{
		get => (ICommand)GetValue(ActionIconCommandProperty);
		set => SetValue(ActionIconCommandProperty, value);
	}

	public static readonly BindableProperty ActionIconBackgroundProperty =
		BindableProperty.Create(nameof(ActionIconBackground), typeof(Brush), typeof(UfoActionCard));

	public Brush ActionIconBackground
	{
		get => (Brush)GetValue(ActionIconBackgroundProperty);
		set => SetValue(ActionIconBackgroundProperty, value);
	}

	public static readonly BindableProperty ActionIconImageSourceProperty =
		BindableProperty.Create(nameof(ActionIconImageSource), typeof(ImageSource), typeof(UfoActionCard));

	public ImageSource ActionIconImageSource
	{
		get => (ImageSource)GetValue(ActionIconImageSourceProperty);
		set => SetValue(ActionIconImageSourceProperty, value);
	}

	public static readonly BindableProperty ActionIconLayoutOptionsProperty =
	BindableProperty.Create(nameof(ActionIconLayoutOptions), typeof(LayoutOptions), typeof(UfoActionCard));

	public LayoutOptions ActionIconLayoutOptions
	{
		get => (LayoutOptions)GetValue(ActionIconLayoutOptionsProperty);
		set => SetValue(ActionIconLayoutOptionsProperty, value);
	}

	public static readonly BindableProperty ActionSizeProperty =
		BindableProperty.Create(nameof(ActionIconSize), typeof(double), typeof(UfoActionCard));

	public double ActionIconSize
	{
		get => (double)GetValue(ActionSizeProperty);
		set => SetValue(ActionSizeProperty, value);
	}
	
	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		if (propertyName == nameof(ActionIconSize))
		{
			ActionButton.HeightRequest = ActionIconSize;
			ActionButton.WidthRequest= ActionIconSize;

			var cornerRadius = (int)(ActionIconSize / 2);
			ActionButton.CornerRadius = cornerRadius;
			ActionButton.Margin = new Thickness(0, 0, 10, -cornerRadius);
		}
	}
}