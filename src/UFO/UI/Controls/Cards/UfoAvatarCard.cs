using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using UFO.UI.Builders;

namespace UFO.UI.Controls.Cards;

public class UfoAvatarCard : UfoCard
{
	public static readonly BindableProperty AvatarBackgroundColorProperty = BindableProperty.Create(nameof(AvatarBackgroundColor), typeof(Color), typeof(UfoAvatarCard), defaultValue: Colors.White);
	public static readonly BindableProperty AvatarBorderColorProperty = BindableProperty.Create(nameof(AvatarBorderColor), typeof(Color), typeof(UfoAvatarCard), Colors.LightGray);
	public static readonly BindableProperty AvatarBorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(UfoAvatarCard), 2.0);
	public static readonly BindableProperty AvatarSizeProperty = BindableProperty.Create(nameof(AvatarSize), typeof(double), typeof(UfoAvatarCard), 60.0);
	public static readonly BindableProperty AvatarTextProperty = BindableProperty.Create(nameof(AvatarText), typeof(string), typeof(UfoAvatarCard), defaultValue: "UFO");
	public static readonly BindableProperty AvatarTextColorProperty = BindableProperty.Create(nameof(AvatarTextColor), typeof(Color), typeof(UfoAvatarCard), defaultValue: Colors.Black);
	public static readonly BindableProperty AvatarImageSourceProperty = BindableProperty.Create(nameof(AvatarImageSource), typeof(ImageSource), typeof(UfoAvatarCard));
	public static readonly BindableProperty AvatarPaddingProperty = BindableProperty.Create(nameof(AvatarPadding), typeof(Thickness), typeof(UfoAvatarCard));	
	public static readonly BindableProperty TopViewProperty = BindableProperty.Create(nameof(TopView), typeof(View), typeof(UfoAvatarCard));
	public static readonly BindableProperty BottomViewProperty = BindableProperty.Create(nameof(BottomView), typeof(View), typeof(UfoAvatarCard));
	
	public UfoAvatarCard()
	{
		Content = new AvatarCardLayoutBuilder(this).Build();
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

internal sealed class AvatarCardLayoutBuilder : CardLayoutBuilder
{
	private readonly UfoAvatarCard _ufoAvatarCard;
	private readonly ContentView _bottomView = new() { Padding = 0 };
	private readonly ContentView _topView = new() { Padding = 0 };

	private readonly AvatarView _avatarView = new()
	{
		VerticalOptions = LayoutOptions.End,
		BackgroundColor = Colors.White
	};

	public AvatarCardLayoutBuilder(UfoAvatarCard ufoAvatarCard)
	{
		_ufoAvatarCard = ufoAvatarCard;
		_ufoAvatarCard.PropertyChanged += UfoAvatarCard_PropertyChanged;
		_ufoAvatarCard.Unloaded += UfoAvatarCard_Unloaded;

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
		ControlGridContainer.Children.Add(_avatarView);
		ControlGridContainer.Children.Add(CloseButton);

		Grid.SetRow(_bottomView, 1);
		Grid.SetRow(_topView, 0);
		Grid.SetRow(CloseButton, 0);
		Grid.SetRow(_avatarView, 0);

		CardFrameContainer.Content = ControlGridContainer;
	}

	private void UfoAvatarCard_Unloaded(object sender, EventArgs e)
	{
		_ufoAvatarCard.PropertyChanged -= UfoAvatarCard_PropertyChanged;
		_ufoAvatarCard.Unloaded -= UfoAvatarCard_Unloaded;
	}

	private void UfoAvatarCard_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		SetCardFrameProperties(e.PropertyName, _ufoAvatarCard);

		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarBackgroundColor)) _avatarView.BackgroundColor = _ufoAvatarCard.BackgroundColor;
		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarBorderColor)) _avatarView.BorderColor = _ufoAvatarCard.AvatarBorderColor;
		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarBorderWidth)) _avatarView.BorderWidth = _ufoAvatarCard.AvatarBorderWidth;

		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarSize))
		{
			var size = _ufoAvatarCard.AvatarSize;
			_avatarView.HeightRequest = size;
			_avatarView.WidthRequest = size;
			_avatarView.CornerRadius = size / 2;
			_avatarView.Margin = new Thickness(0, 0, 0, -(size / 2));
		}

		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarText)) _avatarView.Text = _ufoAvatarCard.AvatarText;
		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarTextColor)) _avatarView.TextColor = _ufoAvatarCard.AvatarTextColor;
		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarImageSource)) _avatarView.ImageSource = _ufoAvatarCard.AvatarImageSource;
		if (e.PropertyName == nameof(_ufoAvatarCard.AvatarPadding)) _avatarView.Padding = _ufoAvatarCard.AvatarPadding;

		if (e.PropertyName == nameof(_ufoAvatarCard.TopView)) _topView.Content = _ufoAvatarCard.TopView;
		if (e.PropertyName == nameof(_ufoAvatarCard.BottomView)) _bottomView.Content = _ufoAvatarCard.BottomView;

		SetCloseButtonProperties(e.PropertyName, _ufoAvatarCard);
	}
}
