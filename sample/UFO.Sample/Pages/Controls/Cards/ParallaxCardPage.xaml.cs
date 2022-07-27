using UFO.Sample.ViewModels.Controls.Cards;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class ParallaxCardPage
{
	public ParallaxCardPage(ParallaxCardViewModel parallaxCardViewModel)
	{
		InitializeComponent();
		BindingContext = parallaxCardViewModel;
	}
}