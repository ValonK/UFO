using UFO.Sample.ViewModels.Controls;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class CardsPage
{
	public CardsPage(CardsViewModel cardsViewModel)
	{
		InitializeComponent();
		BindingContext = cardsViewModel;
	}
}