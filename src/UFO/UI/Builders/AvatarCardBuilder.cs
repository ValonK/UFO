using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using UFO.UI.Controls.Cards;

namespace UFO.UI.Builders;

internal sealed class AvatarCardBuilder : LayoutBuilder
{
	private readonly UfoAvatarCard _ufoAvatarCard;
	private readonly Frame _cardFrameContainer = new() { Padding = 0 };
	private readonly Grid _controlGridContainer = new();
	private readonly ContentView _bottomView = new() { Padding = 0 };
	private readonly ContentView _topView = new() { Padding = 0 };
	
	private readonly AvatarView _avatarView = new()
	{
		VerticalOptions = LayoutOptions.End,
	};
	
	private readonly Button _closeButton = new() 
	{
		Padding = 0,
		VerticalOptions = LayoutOptions.Start,
		HorizontalOptions = LayoutOptions.End,
		Margin = new Thickness(0, 5, 5, 0),
	};

	public AvatarCardBuilder(UfoAvatarCard ufoAvatarCard)
	{
		_ufoAvatarCard = ufoAvatarCard;
		_ufoAvatarCard.PropertyChanged += UfoAvatarCard_PropertyChanged;
		_ufoAvatarCard.Unloaded += UfoAvatarCard_Unloaded;
		
		Construct();
	}

	internal override View Build()
	{
		return _cardFrameContainer;
	}

	protected override void Construct()
	{
		_controlGridContainer.RowDefinitions.Add(new(GridLength.Star));
		_controlGridContainer.RowDefinitions.Add(new(GridLength.Star));
		_controlGridContainer.Children.Add(_bottomView);
		_controlGridContainer.Children.Add(_topView);
		_controlGridContainer.Children.Add(_avatarView);
		_controlGridContainer.Children.Add(_closeButton);

		Grid.SetRow(_bottomView, 1);
		Grid.SetRow(_topView, 0);
		Grid.SetRow(_closeButton, 0);
		Grid.SetRow(_avatarView, 0);

		_cardFrameContainer.Content = _controlGridContainer;
	}

	private void UfoAvatarCard_Unloaded(object sender, EventArgs e)
	{
		_ufoAvatarCard.PropertyChanged -= UfoAvatarCard_PropertyChanged;
		_ufoAvatarCard.Unloaded -= UfoAvatarCard_Unloaded;
	}

	private void UfoAvatarCard_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
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
		
		if (e.PropertyName == nameof(_ufoAvatarCard.CornerRadius)) _cardFrameContainer.CornerRadius = _ufoAvatarCard.CornerRadius;
		if (e.PropertyName == nameof(_ufoAvatarCard.BorderColor)) _cardFrameContainer.BorderColor = _ufoAvatarCard.BorderColor;
		if (e.PropertyName == nameof(_ufoAvatarCard.Command))
		{
			var tapGestureRecognizer = new TapGestureRecognizer
			{
				Command = _ufoAvatarCard.Command
			};
			_cardFrameContainer.GestureRecognizers.Clear();
			_cardFrameContainer.GestureRecognizers.Add(tapGestureRecognizer);
		}

		if (e.PropertyName == nameof(_ufoAvatarCard.CloseBackground)) _closeButton.Background = _ufoAvatarCard.CloseBackground;
		if (e.PropertyName == nameof(_ufoAvatarCard.CloseImageSource)) _closeButton.ImageSource = _ufoAvatarCard.CloseImageSource;
		if (e.PropertyName == nameof(_ufoAvatarCard.CloseCommand)) _closeButton.Command = _ufoAvatarCard.CloseCommand;
		if (e.PropertyName == nameof(_ufoAvatarCard.CloseSize))
		{
			var size = _ufoAvatarCard.CloseSize;
			_closeButton.HeightRequest = size;
			_closeButton.WidthRequest = size;
			_closeButton.CornerRadius = (int)(size / 2);
		} 
	}
}