using System.ComponentModel;
using UFO.UI.Controls.Cards;

namespace UFO.UI.Builders;

internal sealed class ActionCardBuilder : LayoutBuilder
{
	private readonly UfoActionCard _ufpActionCard;
	private readonly Frame _cardFrameContainer = new() { Padding = 0};
	private readonly Grid _controlGridContainer = new();
	private readonly ContentView _bottomView = new() { Padding = 0 };
	private readonly ContentView _topView = new() { Padding = 0 };
	private readonly Button _actionButton = new() { Padding = 0, VerticalOptions = LayoutOptions.End };

	public ActionCardBuilder(UfoActionCard ufoCard)
	{
		_ufpActionCard = ufoCard;
		_ufpActionCard.Unloaded += UfoActionCard_Unloaded;
		_ufpActionCard.PropertyChanged += UfoActionCard_PropertyChanged;
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
		_controlGridContainer.Children.Add(_actionButton);

		Grid.SetRow(_bottomView, 1);
		Grid.SetRow(_topView, 0);
		Grid.SetRow(_actionButton, 0);

		_cardFrameContainer.Content = _controlGridContainer;
	}

	private void UfoActionCard_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(_ufpActionCard.BorderColor)) _cardFrameContainer.BorderColor = _ufpActionCard.BorderColor;
		if (e.PropertyName == nameof(_ufpActionCard.CornerRadius)) _cardFrameContainer.CornerRadius = _ufpActionCard.CornerRadius;
		if (e.PropertyName == nameof(_ufpActionCard.BottomView)) _bottomView.Content = _ufpActionCard.BottomView;
		if (e.PropertyName == nameof(_ufpActionCard.TopView)) _topView.Content = _ufpActionCard.TopView;
		if (e.PropertyName == nameof(_ufpActionCard.IconLayoutOptions)) _actionButton.HorizontalOptions = _ufpActionCard.IconLayoutOptions;
		if (e.PropertyName == nameof(_ufpActionCard.IconImageSource)) _actionButton.ImageSource = _ufpActionCard.IconImageSource;
		if (e.PropertyName == nameof(_ufpActionCard.IconBackground)) _actionButton.Background = _ufpActionCard.IconBackground;
		if (e.PropertyName == nameof(_ufpActionCard.IconCommand)) _actionButton.Command = _ufpActionCard.IconCommand;
		if (e.PropertyName == nameof(_ufpActionCard.HasActionButton)) _actionButton.IsVisible = _ufpActionCard.HasActionButton;

		if (e.PropertyName == nameof(_ufpActionCard.IconSize))
		{
			var size = _ufpActionCard.IconSize;
			_actionButton.HeightRequest = size;
			_actionButton.WidthRequest = size;

			var cornerRadius = (int)(size / 2);
			_actionButton.CornerRadius = cornerRadius;
			_actionButton.Margin = new Thickness(0, 0, 10, -cornerRadius);
		}
	}

	private void UfoActionCard_Unloaded(object sender, EventArgs e)
	{
		_ufpActionCard.Unloaded -= UfoActionCard_Unloaded;
		_ufpActionCard.PropertyChanged -= UfoActionCard_PropertyChanged;
	}
}