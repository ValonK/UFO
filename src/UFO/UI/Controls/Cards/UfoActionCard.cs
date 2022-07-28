using System.ComponentModel;
using System.Windows.Input;
using UFO.UI.Builders;
using UFO.Utilities;

namespace UFO.UI.Controls.Cards;

public class UfoActionCard : UfoCard
{	
	public static readonly BindableProperty IsActionButtonVisibleProperty = BindableProperty.Create(nameof(IsActionButtonVisible), typeof(bool), typeof(UfoActionCard), defaultValue: true);
	public static readonly BindableProperty ActionButtonCommandProperty = BindableProperty.Create(nameof(ActionButtonCommand), typeof(ICommand), typeof(UfoActionCard));
	public static readonly BindableProperty ActionButtonBackgroundProperty = BindableProperty.Create(nameof(ActionButtonBackground), typeof(Brush), typeof(UfoActionCard), new SolidColorBrush(UfoColors.UfoPrimaryColor));
	public static readonly BindableProperty ActionButtonImageSourceProperty = BindableProperty.Create(nameof(ActionButtonImageSource), typeof(ImageSource), typeof(UfoActionCard));
	public static readonly BindableProperty ActionButtonLayoutOptionsProperty = BindableProperty.Create(nameof(ActionButtonLayoutOptions), typeof(LayoutOptions), typeof(UfoActionCard), defaultValue: LayoutOptions.End);
	public static readonly BindableProperty ActionButtonSizeProperty = BindableProperty.Create(nameof(ActionButtonSize), typeof(double), typeof(UfoActionCard), defaultValue: 60.0);
	public static readonly BindableProperty TopViewProperty = BindableProperty.Create(nameof(TopView), typeof(View), typeof(UfoAvatarCard));
	public static readonly BindableProperty BottomViewProperty = BindableProperty.Create(nameof(BottomView), typeof(View), typeof(UfoAvatarCard));
	
	public UfoActionCard()
	{
		Content = new ActionCardLayoutBuilder(this).Build();
	}

	public bool IsActionButtonVisible
	{
		get => (bool)GetValue(IsActionButtonVisibleProperty);
		set => SetValue(IsActionButtonVisibleProperty, value);
	}

	public ICommand ActionButtonCommand
	{
		get => (ICommand)GetValue(ActionButtonCommandProperty);
		set => SetValue(ActionButtonCommandProperty, value);
	}

	public Brush ActionButtonBackground
	{
		get => (Brush)GetValue(ActionButtonBackgroundProperty);
		set => SetValue(ActionButtonBackgroundProperty, value);
	}

	public ImageSource ActionButtonImageSource
	{
		get => (ImageSource)GetValue(ActionButtonImageSourceProperty);
		set => SetValue(ActionButtonImageSourceProperty, value);
	}

	public LayoutOptions ActionButtonLayoutOptions
	{
		get => (LayoutOptions)GetValue(ActionButtonLayoutOptionsProperty);
		set => SetValue(ActionButtonLayoutOptionsProperty, value);
	}

	public double ActionButtonSize
	{
		get => (double)GetValue(ActionButtonSizeProperty);
		set => SetValue(ActionButtonSizeProperty, value);
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

internal sealed class ActionCardLayoutBuilder : CardLayoutBuilder
{
	private readonly UfoActionCard _actionCard;
	private readonly ContentView _bottomView = new() { Padding = 0 };
	private readonly ContentView _topView = new() { Padding = 0 };
	private readonly Button _actionButton = new() { Padding = 0, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.End };

	public ActionCardLayoutBuilder(UfoActionCard ufoCard)
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
		if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
		{
			_actionCard.MaximumWidthRequest = 450;
		}

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
		if (e.PropertyName == nameof(_actionCard.ActionButtonLayoutOptions))
		{
			_actionButton.HorizontalOptions = _actionCard.ActionButtonLayoutOptions;
			SetActionButton();
		}
		
		if (e.PropertyName == nameof(_actionCard.ActionButtonImageSource)) _actionButton.ImageSource = _actionCard.ActionButtonImageSource;
		if (e.PropertyName == nameof(_actionCard.ActionButtonBackground)) _actionButton.Background = _actionCard.ActionButtonBackground;
		if (e.PropertyName == nameof(_actionCard.ActionButtonCommand)) _actionButton.Command = _actionCard.ActionButtonCommand;
		if (e.PropertyName == nameof(_actionCard.IsActionButtonVisible)) _actionButton.IsVisible = _actionCard.IsActionButtonVisible;

		if (e.PropertyName == nameof(_actionCard.ActionButtonSize)) SetActionButton();
		
		SetCloseButtonProperties(e.PropertyName, _actionCard);
	}

	private void SetActionButton()
	{
		var size = _actionCard.ActionButtonSize;
		_actionButton.HeightRequest = size;
		_actionButton.WidthRequest = size;

		var cornerRadius = (int)(size / 2);
		_actionButton.CornerRadius = cornerRadius;

		_actionButton.Margin = _actionCard.ActionButtonLayoutOptions.Alignment switch
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