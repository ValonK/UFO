using UFO.Sample.ViewModels.Controls.Cards;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class AvatarCardPage 
{
	public AvatarCardPage(AvatarCardViewModel avatarCardViewModel)
	{
		InitializeComponent();
		BindingContext = avatarCardViewModel;
	}
}