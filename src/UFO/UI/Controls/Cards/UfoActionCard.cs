using System.ComponentModel;
using System.Windows.Input;
using UFO.UI.Builders;
using UFO.Utilities;

namespace UFO.UI.Controls.Cards;

public class UfoActionCard : UfoCard
{	
	public static readonly BindableProperty HasActionButtonProperty = BindableProperty.Create(nameof(HasActionButton), typeof(bool), typeof(UfoActionCard), defaultValue: true);
	public static readonly BindableProperty IconCommandProperty = BindableProperty.Create(nameof(IconCommand), typeof(ICommand), typeof(UfoActionCard));
	public static readonly BindableProperty IconBackgroundProperty = BindableProperty.Create(nameof(IconBackground), typeof(Brush), typeof(UfoActionCard), new SolidColorBrush(UfoColors.UfoPrimaryColor));
	public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoActionCard));
	public static readonly BindableProperty IconLayoutOptionsProperty = BindableProperty.Create(nameof(IconLayoutOptions), typeof(LayoutOptions), typeof(UfoActionCard), defaultValue: LayoutOptions.End);
	public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(UfoActionCard), defaultValue: 60.0);
	public static readonly BindableProperty TopViewProperty = BindableProperty.Create(nameof(TopView), typeof(View), typeof(UfoAvatarCard));
	public static readonly BindableProperty BottomViewProperty = BindableProperty.Create(nameof(BottomView), typeof(View), typeof(UfoAvatarCard));
	
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
}

internal sealed class ActionCardBuilder : CardLayoutBuilder
{
	private readonly UfoActionCard _actionCard;
	private readonly ContentView _bottomView = new() { Padding = 0 };
	private readonly ContentView _topView = new() { Padding = 0 };
	private readonly Button _actionButton = new() { Padding = 0, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.End };

	public ActionCardBuilder(UfoActionCard ufoCard)
	{
		_actionCard = ufoCard;
		_actionCard.Unloaded += UfoActionCard_Unloaded;
		_actionCard.PropertyChanged += UfoActionCard_PropertyChanged;
		Construct();
	}

	internal override View Build()
	{
		return CardFrameContainer;
	}

	protected override void Construct()
	{
		ControlGridContainer.RowDefinitions.Add(new(GridLength.Star));
		ControlGridContainer.RowDefinitions.Add(new(GridLength.Star));
		ControlGridContainer.Children.Add(_bottomView);
		ControlGridContainer.Children.Add(_topView);
		ControlGridContainer.Children.Add(_actionButton);
		ControlGridContainer.Children.Add(CloseButton);

		Grid.SetRow(_bottomView, 1);
		Grid.SetRow(_topView, 0);
		Grid.SetRow(_actionButton, 0);
		Grid.SetRow(CloseButton, 0);

		CardFrameContainer.Content = ControlGridContainer;
	}

	private void UfoActionCard_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		SetCardFrameProperties(e.PropertyName, _actionCard);
		
		if (e.PropertyName == nameof(_actionCard.BottomView)) _bottomView.Content = _actionCard.BottomView;
		if (e.PropertyName == nameof(_actionCard.TopView)) _topView.Content = _actionCard.TopView;
		if (e.PropertyName == nameof(_actionCard.IconLayoutOptions))
		{
			_actionButton.HorizontalOptions = _actionCard.IconLayoutOptions;
			SetActionButton();
		}
		
		if (e.PropertyName == nameof(_actionCard.IconImageSource)) _actionButton.ImageSource = _actionCard.IconImageSource;
		if (e.PropertyName == nameof(_actionCard.IconBackground)) _actionButton.Background = _actionCard.IconBackground;
		if (e.PropertyName == nameof(_actionCard.IconCommand)) _actionButton.Command = _actionCard.IconCommand;
		if (e.PropertyName == nameof(_actionCard.HasActionButton)) _actionButton.IsVisible = _actionCard.HasActionButton;

		if (e.PropertyName == nameof(_actionCard.IconSize)) SetActionButton();
		
		SetCloseButtonProperties(e.PropertyName, _actionCard);
	}

	private void SetActionButton()
	{
		var size = _actionCard.IconSize;
		_actionButton.HeightRequest = size;
		_actionButton.WidthRequest = size;

		var cornerRadius = (int)(size / 2);
		_actionButton.CornerRadius = cornerRadius;

		_actionButton.Margin = _actionCard.IconLayoutOptions.Alignment switch
		{
			LayoutAlignment.Start => new Thickness(10, 0, 0, -cornerRadius),
			LayoutAlignment.Center => new Thickness(0, 0, 0, -cornerRadius),
			LayoutAlignment.End => new Thickness(0, 0, 10, -cornerRadius),
			LayoutAlignment.Fill => new Thickness(0, 0, 0, -cornerRadius),
			_ => _actionButton.Margin
		};
	}

	private void UfoActionCard_Unloaded(object sender, EventArgs e)
	{
		_actionCard.Unloaded -= UfoActionCard_Unloaded;
		_actionCard.PropertyChanged -= UfoActionCard_PropertyChanged;
	}
}