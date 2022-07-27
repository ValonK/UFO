using UFO.Sample.ViewModels.Controls.Cards;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class ActionCardPage
{
	public ActionCardPage(ActionsCardViewModel actionsCardViewModel)
	{
		InitializeComponent();
		BindingContext = actionsCardViewModel;
	}
}