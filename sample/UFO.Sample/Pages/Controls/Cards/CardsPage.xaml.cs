using UFO.Sample.ViewModels.Controls;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class CardsPage : ContentPage
{
	public CardsPage(CardsViewModel cardsViewModel)
	{
		InitializeComponent();
		BindingContext = cardsViewModel;
	}
}